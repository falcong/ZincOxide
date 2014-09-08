//
//  CSharpCommandContract.cs
//
//  Author:
//       Willem Van Onsem <vanonsem.willem@gmail.com>
//
//  Copyright (c) 2014 Willem Van Onsem
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
using System;
using System.Diagnostics.Contracts;
using System.CodeDom;
using System.Collections.Generic;

namespace ZincOxide.Codegen.Abstract.OO.CSharp {

	/// <summary>
	/// A contract class for <see cref="ICSharpCommand"/> instances.
	/// </summary>
	[ContractClassFor(typeof(ICSharpCommand))]
	public abstract class CSharpCommandContract : ICSharpCommand {

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="CSharpCommandContract"/> class.
		/// </summary>
		protected CSharpCommandContract () {
		}
		#endregion
		#region ICSharpCommand implementation
		/// <summary>
		/// Enumerate one or more <see cref="CodeObject"/> instances that mimic the behavior of
		/// this <see cref="ICSharpCommand"/>.
		/// </summary>
		/// <returns>A <see cref="T:IEnumerable`1"/> of <see cref="CodeObject"/> instance mimicking
		/// this <see cref="ICSharpCommand"/>.</returns>
		/// <remarks>
		/// <para>The result is guaranteed to be effective as are all the <see cref="CodeObject"/> instances.</para>
		/// </remarks>
		public IEnumerable<CodeObject> EnumerateCode () {
			Contract.Ensures (Contract.Result<IEnumerable<CodeObject>> () != null);
			Contract.Ensures (Contract.ForAll (Contract.Result<IEnumerable<CodeObject>> (), x => x != null));
			return default(IEnumerable<CodeObject>);
		}
		#endregion
	}
}

