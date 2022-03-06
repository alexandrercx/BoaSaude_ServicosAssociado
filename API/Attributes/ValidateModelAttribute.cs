using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Attributes
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            bool clear = true;
            if (context.ActionArguments.Count > 0)
            {
                foreach (var item in context.ActionArguments)
                {
                    if (clear)
                    {
                        context.ModelState.Clear();
                        clear = false;
                    }

                    object model = item.Value;
                    if (model is IValidatableObject)
                    {
                        var errors = ((IValidatableObject)model).Validate(new ValidationContext(model));

                        if (errors.Count() > 0)
                        {
                            foreach (var error in errors)
                                foreach (var memberName in error.MemberNames)
                                    context.ModelState.AddModelError(memberName, error.ErrorMessage);
                        }
                    }
                }
            }

            if (!context.ModelState.IsValid)
            {
                context.Result = new BadRequestObjectResult(context.ModelState);
            }
        }
    }
}
