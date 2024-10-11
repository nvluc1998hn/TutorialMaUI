﻿using Plugin.ValidationRules.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorialMaUI.Resources.Language;

namespace TutorialMaUI.Validations
{
    public class UserNameRule : IValidationRule<string>
    {
        public string ValidationMessage { get; set; }

        public bool Check(string value)
        {
            if (!String.IsNullOrEmpty(value))
            {
                if (value.Length > 50)
                {
                    ValidationMessage = String.Format(AppResources.MaxLength50, AppResources.UserName);
                    return false;
                }
            }
            return true;
        }
    }
}
