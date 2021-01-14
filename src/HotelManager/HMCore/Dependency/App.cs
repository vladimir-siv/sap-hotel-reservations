using System;
using System.Collections.Specialized;
using HMCore.Database;

namespace HMCore
{
	public static class App
	{
		public static bool Initialized { get; private set; } = false;

		public static void Init(NameValueCollection settings)
		{
			if (Initialized) throw new ApplicationException("Application has already been initialized.");
			if (settings == null) throw new ArgumentNullException(nameof(settings));

			string aqn = typeof(HMDatabase).AssemblyQualifiedName;
			string dbTypeAqn = settings["Database"] + aqn.Substring(aqn.IndexOf(','));
			Type dbType = Type.GetType(dbTypeAqn);
			HMDatabase db = (HMDatabase)Activator.CreateInstance(dbType);
			Dependency.Inject(db);

			Initialized = true;
		}

		public static void Dispose()
		{
			if (!Initialized) throw new ApplicationException("Application has not been initialized.");

			HMDatabase db = Dependency.Resolve<HMDatabase>();
			db.Dispose();

			Dependency.Dispose();

			Initialized = false;
		}
	}
}
