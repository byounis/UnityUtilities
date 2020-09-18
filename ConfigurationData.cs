﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/// <summary>
/// Provides access to configuration data
/// </summary>
public class ConfigurationData
{
	#region Fields

    const string ConfigurationDataFileName = "ConfigurationData.csv";
    Dictionary<ConfigurationDataValueName, float> values =
        new Dictionary<ConfigurationDataValueName, float>();

	#endregion

	#region Properties

	/// <summary>
	/// Gets the number of seconds in a game
	/// </summary>
	public int TotalGameSeconds
    {
        get { return (int)values[ConfigurationDataValueName.TotalGameSeconds]; }
	}
	#endregion

    #region Constructor

    /// <summary>
    /// Constructor
    /// Reads configuration data from a file. If the file
    /// read fails, the object contains default values for
    /// the configuration data
    /// </summary>
    public ConfigurationData()
    {
        // read and save configuration data from file
        StreamReader input = null;
        try
        {
            // create stream reader object
            input = File.OpenText(Path.Combine(
                Application.streamingAssetsPath, ConfigurationDataFileName));

            // populate values
            string currentLine = input.ReadLine();
            while (currentLine != null)
            {
                string[] tokens = currentLine.Split(',');
                ConfigurationDataValueName valueName = 
                    (ConfigurationDataValueName)Enum.Parse(
                        typeof(ConfigurationDataValueName), tokens[0]);
                values.Add(valueName, float.Parse(tokens[1]));
                currentLine = input.ReadLine();
            }
        }
        catch (Exception e)
        {
            // set default values if something went wrong
            SetDefaultValues();
        }
        finally
        {
            // always close input file
            if (input != null)
            {
                input.Close();
            }
        }
    }

    #endregion

    /// <summary>
    /// Sets the configuration data fields to default values
    /// csv string
    /// </summary>
    void SetDefaultValues()
    {
        values.Clear();
        values.Add(ConfigurationDataValueName.TotalGameSeconds, 30);
    }
}