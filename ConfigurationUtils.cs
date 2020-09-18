using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provides utility access to configuration data
/// </summary>
public static class ConfigurationUtils
{
	#region Fields

	static ConfigurationData configurationData;

	#endregion

	#region Properties

	/// <summary>
	/// Gets the number of seconds in a game
	/// </summary>
	public static int TotalGameSeconds
    {
		get { return configurationData.TotalGameSeconds; }
	}
	#endregion

	#region Public methods

	/// <summary>
	/// Initializes the configuration data by creating the ConfigurationData object 
	/// </summary>
	public static void Initialize()
	{
        configurationData = new ConfigurationData();
	}

	#endregion
}
