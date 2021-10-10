using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using Generator;

namespace FakerLibrary
{
    public class FakerConfig : IFakerConfig
    {
        private readonly Dictionary<MemberInfo, IGenerator> _generators = new();

        public void Add<TClass, TPropertyType, TGenerator>(Expression<Func<TClass, TPropertyType>> expression)
            where TGenerator : IGenerator, new()
        {

        }

        public IGenerator GetGenerator(MemberInfo memberInfo)
        {

        }
    }
}