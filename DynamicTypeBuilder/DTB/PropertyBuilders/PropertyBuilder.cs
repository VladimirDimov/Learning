namespace DTB
{
    using System;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Reflection.Emit;

    public class PropertyBuilder
    {
        private readonly TypeBuilder typeBuilder;
        private readonly Type returnType;
        private readonly string propertyName;

        private PropertyAttributes propertyAttributes;
        private FieldBuilder fieldBuilder;
        private System.Reflection.Emit.MethodBuilder getPropertyMethodBuilder;
        private System.Reflection.Emit.MethodBuilder setPropertyMethodBuilder;

        public PropertyBuilder(TypeBuilder typeBuilder, string name, Type returnType)
        {
            this.typeBuilder = typeBuilder;
            this.propertyName = name;
            this.returnType = returnType;

            this.SetDefaultValues();
        }

        private void SetDefaultValues()
        {
            this.propertyAttributes = PropertyAttributes.HasDefault;
        }

        public PropertyBuilder SetGetter(MethodAttributes attributes)
        {
            System.Reflection.Emit.MethodBuilder getPropertyMethodBuilder =
                    this.typeBuilder.DefineMethod(
                        $"get_{this.propertyName}",
                        attributes,
                        returnType,
                        Type.EmptyTypes);

            ILGenerator generator = getPropertyMethodBuilder.GetILGenerator();

            generator.Emit(OpCodes.Ldarg_0);
            if (this.fieldBuilder != null)
            {
                generator.Emit(OpCodes.Ldfld, this.fieldBuilder);
            }

            generator.Emit(OpCodes.Ret);

            this.getPropertyMethodBuilder = getPropertyMethodBuilder;

            return this;
        }

        public PropertyBuilder SetPropertyAttributes(PropertyAttributes attributes)
        {
            this.propertyAttributes = attributes;

            return this;
        }

        public PropertyBuilder SetSetter(MethodAttributes attributes)
        {
            System.Reflection.Emit.MethodBuilder setPropertyMethodBuilder =
                this.typeBuilder.DefineMethod(
                    $"set_{this.propertyName}",
                    attributes,
                    null,
                    new Type[] { returnType });

            ILGenerator propSetIL = setPropertyMethodBuilder.GetILGenerator();

            Label modifyProperty = propSetIL.DefineLabel();
            Label exitSet = propSetIL.DefineLabel();
            propSetIL.MarkLabel(modifyProperty);

            propSetIL.Emit(OpCodes.Ldarg_0);
            propSetIL.Emit(OpCodes.Ldarg_1);
            propSetIL.Emit(OpCodes.Stfld, this.fieldBuilder);
            propSetIL.Emit(OpCodes.Ret);

            this.setPropertyMethodBuilder = setPropertyMethodBuilder;

            return this;
        }

        public PropertyBuilder UseField()
        {
            FieldBuilder fieldBuilder = typeBuilder.DefineField("_" + this.propertyName, this.returnType, FieldAttributes.Private);
            this.fieldBuilder = fieldBuilder;

            return this;
        }

        internal void Build()
        {
            System.Reflection.Emit.PropertyBuilder currentPropertyBuilder = this.typeBuilder
                .DefineProperty(this.propertyName, this.propertyAttributes, this.returnType, null);

            currentPropertyBuilder.SetGetMethod(this.getPropertyMethodBuilder);
        }
    }
}