﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information
namespace DotNetNuke.Abstractions.Settings
{
    using System.Collections.Generic;

    /// <summary>
    /// The settings service defines APIs for
    /// retrieving or saving standard DNN settings.
    /// </summary>
    public interface ISettingsService
    {
        /// <summary>
        /// Gets the setting value by the specific key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>host setting's value.</returns>
        /// <exception cref="System.ArgumentException">key is empty.</exception>
        bool GetBoolean(string key);

        /// <summary>
        /// Gets the setting value by the specific key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="defaultValue">this value will be return if setting's value is empty.</param>
        /// <returns>host setting's value.</returns>
        /// <exception cref="System.ArgumentException">key is empty.</exception>
        bool GetBoolean(string key, bool defaultValue);

        /// <summary>
        /// Gets the setting value by the specific key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>host setting's value.</returns>
        /// <exception cref="System.ArgumentException">key is empty.</exception>
        double GetDouble(string key);

        /// <summary>
        /// Gets the setting value by the specific key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="defaultValue">this value will be return if setting's value is empty.</param>
        /// <returns>host setting's value.</returns>
        /// <exception cref="System.ArgumentException">key is empty.</exception>
        double GetDouble(string key, double defaultValue);

        /// <summary>
        /// takes in a text value, decrypts it with a FIPS compliant algorithm and returns the value.
        /// </summary>
        /// <param name="key">the host setting to read.</param>
        /// <param name="passPhrase">the pass phrase used for encryption/decryption.</param>
        /// <returns>The setting value as a <see cref="string"/>.</returns>
        string GetEncryptedString(string key, string passPhrase);

        /// <summary>
        /// takes in a text value, decrypts it with a FIPS compliant algorithm and returns the value.
        /// </summary>
        /// <param name="key">the host setting to read.</param>
        /// <returns>The setting value as a <see cref="string"/>.</returns>
        string GetEncryptedString(string key);

        /// <summary>
        /// Gets the setting value by the specific key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>host setting's value.</returns>
        /// <exception cref="System.ArgumentException">key is empty.</exception>
        int GetInteger(string key);

        /// <summary>
        /// Gets the setting value by the specific key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="defaultValue">this value will be return if setting's value is empty.</param>
        /// <returns>host setting's value.</returns>
        /// <exception cref="System.ArgumentException">key is empty.</exception>
        int GetInteger(string key, int defaultValue);

        /// <summary>
        /// Gets all host settings.
        /// </summary>
        /// <returns>host setting.</returns>
        IDictionary<string, IConfigurationSetting> GetSettings();

        /// <summary>
        /// Gets all host settings as dictionary.
        /// </summary>
        /// <returns>host setting's value.</returns>
        IDictionary<string, string> GetSettingsDictionary();

        /// <summary>
        /// Gets the setting value by the specific key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>host setting's value.</returns>
        /// <exception cref="System.ArgumentException">key is empty.</exception>
        string GetString(string key);

        /// <summary>
        /// Gets the setting value by the specific key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="defaultValue">this value will be return if setting's value is empty.</param>
        /// <returns>host setting's value.</returns>
        /// <exception cref="System.ArgumentException">key is empty.</exception>
        string GetString(string key, string defaultValue);

        /// <summary>
        /// Updates the specified config.
        /// </summary>
        /// <param name="config">The config.</param>
        void Update(IConfigurationSetting config);

        /// <summary>
        /// Updates the specified config.
        /// </summary>
        /// <param name="config">The config.</param>
        /// <param name="clearCache">if set to <c>true</c> will clear cache after updating the setting.</param>
        void Update(IConfigurationSetting config, bool clearCache);

        /// <summary>
        /// Updates the specified settings.
        /// </summary>
        /// <param name="settings">The settings.</param>
        void Update(IDictionary<string, string> settings);

        /// <summary>
        /// Updates the setting for a specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        void Update(string key, string value);

        /// <summary>
        /// Updates the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <param name="clearCache">if set to <c>true</c> will clear cache after update settings.</param>
        void Update(string key, string value, bool clearCache);

        /// <summary>
        /// Takes in a <see cref="string"/> value, encrypts it with a FIPS compliant algorithm and stores it.
        /// </summary>
        /// <param name="key">host settings key.</param>
        /// <param name="value">host settings value.</param>
        /// <param name="passPhrase">pass phrase to allow encryption/decryption.</param>
        void UpdateEncryptedString(string key, string value, string passPhrase);

        /// <summary>
        /// Takes in a <see cref="string"/> value, encrypts it with a FIPS compliant algorithm and stores it.
        /// </summary>
        /// <param name="key">host settings key.</param>
        /// <param name="value">host settings value.</param>
        /// <param name="passPhrase">pass phrase to allow encryption/decryption.</param>
        /// <param name="clearCache">if set to <c>true</c> will clear cache after update settings.</param>
        void UpdateEncryptedString(string key, string value, string passPhrase, bool clearCache);

        /// <summary>
        /// Takes in a <see cref="string"/> value, encrypts it with a FIPS compliant algorithm and stores it.
        /// </summary>
        /// <param name="key">host settings key.</param>
        /// <param name="value">host settings value.</param>
        void UpdateEncryptedString(string key, string value);

        /// <summary>
        /// Takes in a <see cref="string"/> value, encrypts it with a FIPS compliant algorithm and stores it.
        /// </summary>
        /// <param name="key">host settings key.</param>
        /// <param name="value">host settings value.</param>
        /// <param name="clearCache">if set to <c>true</c> will clear cache after update settings.</param>
        void UpdateEncryptedString(string key, string value, bool clearCache);

        void Delete(string key);
    }
}
