﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information
namespace DotNetNuke.Entities.Content.Taxonomy
{
    public class TermUsage
    {
        public int TotalTermUsage { get; set; }
        
        public int MonthTermUsage { get; set; }

        public int WeekTermUsage { get; set; }

        public int DayTermUsage { get; set; }

		/// <summary>
		/// parameterless constructor, so that it can be used in CBO.
		/// </summary>
		public TermUsage()
		{
			
		}

        internal TermUsage(int total, int month, int week, int day)
        {
            TotalTermUsage = total;

            MonthTermUsage = month;

            WeekTermUsage = week;

            DayTermUsage = day;
        }
    }
}
