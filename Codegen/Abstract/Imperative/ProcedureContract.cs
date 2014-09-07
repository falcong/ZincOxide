//
//  ProcedureContract.cs
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
using ZincOxide.Utils.Abstract;
using System.Collections.Generic;

namespace ZincOxide.Codegen.Abstract.Imperative {

	/// <summary>
	/// A contract class for <see cref="IProcedure"/> instances.
	/// </summary>
	[ContractClassFor(typeof(IProcedure))]
	public abstract class ProcedureContract : NameContract, IProcedure {

		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="ProcedureContract"/> class.
		/// </summary>
		protected ProcedureContract () {
		}
		#endregion
		#region IProcedure implementation
		/// <summary>
		/// Enumerate the parameters of the procedure.
		/// </summary>
		/// <returns>The parameters of this <see cref="IProcedure"/>.</returns>
		public IEnumerable<IParameter> GetParameters () {
			Contract.Ensures (Contract.Result<IEnumerable<IParameter>> () != null);
			Contract.Ensures (Contract.ForAll (Contract.Result<IEnumerable<IParameter>> (), x => x != null));
			return default(IEnumerable<IParameter>);
		}
		#endregion
	}
}

