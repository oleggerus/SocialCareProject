using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace SocialCareProject.Extensions
{
    public class ModelStateJsonResult : JsonResult
    {
        private readonly ModelStateDictionary _modelState;

        public ModelStateJsonResult(ModelStateDictionary modelState)
        {
            _modelState = modelState;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");


            //we do it as described here - http://stackoverflow.com/questions/15939944/jquery-post-json-fails-when-returning-null-from-asp-net-mvc

            var response = context.HttpContext.Response;
            response.ContentType = !String.IsNullOrEmpty(ContentType) ? ContentType : "application/json";
            if (ContentEncoding != null)
                response.ContentEncoding = ContentEncoding;

            // Serialize the model errors so they can be presented easily in the browser
            List<string> errors = new List<string>();

            foreach (var entry in _modelState.Where(entry => entry.Value.Errors.Any()).ToList())
                errors.AddRange(entry.Value.Errors.Select(x => x.ErrorMessage).ToList());


            List<string> errorFields = new List<string>();


            foreach (var entry in _modelState.Where(entry => entry.Value.Errors.Any()).ToList())
            {
                if (!string.IsNullOrEmpty(entry.Key))
                    errorFields.Add(entry.Key.ToLower(CultureInfo.InvariantCulture));
            }


            this.Data = new { AllErrors = errors, ErrorFields = errorFields, Errors = _modelState.SerializeErrors() };

            //If you need special handling, you can call another form of SerializeObject below
            var serializedObject = JsonConvert.SerializeObject(Data, Formatting.Indented);
            response.Write(serializedObject);
        }
    }
    public static class ModelStateExtensions
    {
        private static string GetErrorMessage(ModelError error, ModelState modelState)
        {
            if (!string.IsNullOrEmpty(error.ErrorMessage))
            {
                return error.ErrorMessage;
            }
            if (modelState.Value == null)
            {
                return error.ErrorMessage;
            }
            var args = new object[] { modelState.Value.AttemptedValue };
            return string.Format("ValueNotValidForProperty=The value '{0}' is invalid", args);
        }

        public static object SerializeErrors(this ModelStateDictionary modelState)
        {
            return modelState.Where(entry => entry.Value.Errors.Any())
                .ToDictionary(entry => entry.Key, entry => SerializeModelState(entry.Value));
        }

        private static Dictionary<string, object> SerializeModelState(ModelState modelState)
        {
            var dictionary = new Dictionary<string, object>
            {
                ["errors"] = modelState.Errors.Select(x => GetErrorMessage(x, modelState)).ToArray()
            };
            return dictionary;
        }

        public static object ToDataSourceResult(this ModelStateDictionary modelState)
        {
            if (!modelState.IsValid)
            {
                return modelState.SerializeErrors();
            }
            return null;
        }
    }
}