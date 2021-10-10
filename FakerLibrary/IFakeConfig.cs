using System;
using System.Linq.Expressions;
using System.Reflection;
using Generator;

namespace FakerLibrary
{
    public interface IFakerConfig
    {
        void Add<TClass, TPropertyType, TGenerator>(Expression<Func<TClass, TPropertyType>> expression)
            where TGenerator : IGenerator, new();

        IGenerator GetGenerator(MemberInfo memberInfo);
        IGenerator GetGenerator(ParameterInfo parameterInfo, Type type);
    }
}
