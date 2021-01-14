using System;
using System.Collections.Generic;

namespace HMCore
{
	public static class Dependency
	{
		private static readonly Dictionary<Type, object> TypedContext = new Dictionary<Type, object>();
		private static readonly Dictionary<string, object> NamedContext = new Dictionary<string, object>();

		public static void Inject<T>(T obj)
		{
			TypedContext.Add(typeof(T), obj);
		}
		public static T Resolve<T>()
		{
			return (T)TypedContext[typeof(T)];
		}

		public static void Inject(string name, object obj)
		{
			NamedContext.Add(name, obj);
		}
		public static object Resolve(string name)
		{
			return NamedContext[name];
		}
		public static T Resolve<T>(string name)
		{
			return (T)NamedContext[name];
		}

		internal static void Dispose()
		{
			TypedContext.Clear();
			NamedContext.Clear();
		}
	}
}
