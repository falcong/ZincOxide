//
//  ZincIntLiteral.cs
//
//  Author:
//       Willem Van Onsem <vanonsem.willem@gmail.com>
//
//  Copyright (c) 2013 Willem Van Onsem
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
using System.Collections.Generic;

namespace ZincOxide.MiniZinc.Structures {

	public class ZincIntLiteral : ZincNumExpLiteralBase {

		private long value;

		public long Value {
			get {
				return this.value;
			}
		}

		public ZincIntLiteral (string text) {
			this.value = int.Parse (text);
		}

		public ZincIntLiteral (long value) {
			this.value = value;
		}

		public ZincIntLiteral (int value) {
			this.value = value;
		}

		public ZincIntLiteral (short value) {
			this.value = value;
		}

		public ZincIntLiteral (byte value) {
			this.value = value;
		}

		public ZincIntLiteral (uint value) {
			this.value = value;
		}

		public ZincIntLiteral (ushort value) {
			this.value = value;
		}

		public ZincIntLiteral (sbyte value) {
			this.value = value;
		}
		#region ToString method
		/// <summary>
		/// Returns a <see cref="System.String"/> that represents the current <see cref="ZincIntLiteral"/>.
		/// </summary>
		/// <returns>A <see cref="System.String"/> that represents the current <see cref="ZincIntLiteral"/>.</returns>
		/// <remarks>
		/// <para>The result is either the integer typesetted in the decimal number system.</para>
		/// </remarks>
		public override string ToString () {
			return this.value.ToString ();
		}
		#endregion
		public static implicit operator ZincIntLiteral (long value) {
			return new ZincIntLiteral (value);
		}

		public static implicit operator ZincIntLiteral (int value) {
			return new ZincIntLiteral (value);
		}

		public static implicit operator ZincIntLiteral (short value) {
			return new ZincIntLiteral (value);
		}

		public static implicit operator ZincIntLiteral (byte value) {
			return new ZincIntLiteral (value);
		}

		public static implicit operator ZincIntLiteral (uint value) {
			return new ZincIntLiteral (value);
		}

		public static implicit operator ZincIntLiteral (ushort value) {
			return new ZincIntLiteral (value);
		}

		public static implicit operator ZincIntLiteral (sbyte value) {
			return new ZincIntLiteral (value);
		}
	}
}

