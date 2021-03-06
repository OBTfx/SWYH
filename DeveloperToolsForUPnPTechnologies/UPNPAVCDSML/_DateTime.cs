/*   
Copyright 2006 - 2010 Intel Corporation

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

   http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/

using System;
using System.Text;
using System.Runtime.Serialization;

namespace OpenSource.UPnP.AV.CdsMetadata
{

	/// <summary>
	/// This struct wraps the standard DateTime value type
	/// with an IValueType interface.
	/// </summary>
	[Serializable()]
	public struct _DateTime : IValueType
	{
		/// <summary>
		/// Returns the unsigned int value.
		/// Not reliable if IsValid is false.
		/// </summary>
		public object Value { get { return m_Value; } }
		/// <summary>
		/// Indicates if the value returned from Value
		/// is reliable.
		/// </summary>
		public bool IsValid { get { return m_IsValid; } }
		/// <summary>
		/// The actual value.
		/// </summary>
		public readonly DateTime m_Value;
		/// <summary>
		/// Indicates if the value is reliable.
		/// </summary>
		private bool m_IsValid;

		/// <summary>
		/// Creates a valid uint wrapped in an interface.
		/// </summary>
		/// <param name="val"></param>
		public _DateTime (DateTime val)
		{
			m_Value = val;
			m_IsValid = true;
		}
		/// <summary>
		/// Creates an invalid/unassigned uint in an object.
		/// </summary>
		/// <param name="invalid">param is ignored</param>
		public _DateTime (bool invalid)
		{
			m_IsValid = false;
			m_Value = new DateTime(0);
		}

		/// <summary>
		/// Casts the value into its string form. 
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			if (this.m_IsValid)
			{
				return this.m_Value.ToString(); 
			}

			return "";
		}

		/// <summary>
		/// Allows comparisons with standard numerical types
		/// using the underlying uint.CompareTo() method.
		/// If the object is another _DateTime value, it
		/// will properly extract the value for comparison.
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public int CompareTo(object obj)
		{
			System.Type type = obj.GetType();
			object compareToThis = obj;

			if (type == typeof(_DateTime))
			{
				_DateTime ui = (_DateTime) obj;
				compareToThis = ui.m_Value;
			}
			return this.m_Value.CompareTo(compareToThis);
		}
	}
}
