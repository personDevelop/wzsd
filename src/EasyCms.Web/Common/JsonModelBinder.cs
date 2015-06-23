using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text.RegularExpressions;
using System.Web.Script.Serialization;
using System.Globalization;
using Sharp.Common;
using System.ComponentModel;
using System.Reflection;

namespace EasyCms.Web
{
    public class JsonModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            string json = string.Empty;
            var provider = bindingContext.ValueProvider;
            var providerValue = provider.GetValue(bindingContext.ModelName);
            if (providerValue != null)
            {
                json = providerValue.AttemptedValue;
            }
            if (Regex.IsMatch(json, @"^(\[.*\]|{.*})$"))
            {
                return new JavaScriptSerializer().Deserialize(json, bindingContext.ModelType);
            }

            object o = base.BindModel(controllerContext, bindingContext);
            return o;
        }


        protected override object CreateModel(ControllerContext controllerContext, ModelBindingContext bindingContext, Type modelType)
        {
            // fallback to the type's default constructor
            Type typeToCreate = modelType;
            if (typeof(BaseEntity).Equals(typeToCreate.BaseType))
            {
                object o = Activator.CreateInstance(typeToCreate);
                BaseEntity be = o as BaseEntity;
                var provider = bindingContext.ValueProvider;
                foreach (var item in be.GetPrimaryKeyProperty())
                {
                    item.SetValue(be, provider.GetValue(item.Name).AttemptedValue);
                }
                StatusType status = StatusType.add;
                Enum.TryParse<StatusType>(provider.GetValue("RecordStatus").AttemptedValue, out status);
                be.RecordStatus = status;
                return be;
            }
            else
            {
                return base.CreateModel(controllerContext, bindingContext, modelType);
            }

        }


        protected override void SetProperty(ControllerContext controllerContext, ModelBindingContext bindingContext, PropertyDescriptor propertyDescriptor, object value)
        {
            Type typeToCreate = bindingContext.ModelType;
            if (typeToCreate != null && typeof(BaseEntity).Equals(typeToCreate.BaseType))
            {
                ModelMetadata propertyMetadata = bindingContext.PropertyMetadata[propertyDescriptor.Name];
                if (propertyDescriptor.Name == "RecordStatus")
                {
                    return;
                }
                else
                {
                    if (propertyDescriptor.Attributes.Contains(new Sharp.Common.PrimaryKey()))
                    {
                        return;
                    }
                }
            }
            base.SetProperty(controllerContext, bindingContext, propertyDescriptor, value);
        }
    }


    

}