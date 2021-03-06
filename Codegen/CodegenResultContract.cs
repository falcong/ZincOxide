//
//  CodegenResultContract.cs
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

namespace ZincOxide.Codegen {

	/// <summary>
	/// A class describing the contracts that are assigned to the <see cref="ICodegenResult"/> interface.
	/// </summary>
	[ContractClassFor(typeof(ICodegenResult))]
	public abstract class CodegenResultContract : ICodegenResult {
		#region ICodegenResult implementation
		/// <summary>
		/// Get the environment that determines how the code should be written.
		/// </summary>
		/// <value>A <see cref="ICodegenEnvironment"/> instance specifying how code should be written.</value>
		public ICodegenEnvironment Environment {
			get {
				Contract.Ensures (Contract.Result<ICodegenEnvironment> () != null);
				return default(ICodegenEnvironment);
			}
		}
		#endregion
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="CodegenResultContract"/> class to assign the proper contracts
		/// to the given code generation.
		/// </summary>
		protected CodegenResultContract () {
		}
		#endregion
		#region ICodegenResult implementation
		/// <summary>
		/// Emit the generated code to file, the standard output or print the appropriate errors.
		/// </summary>
		public void Emit () {
		}
		#endregion
	}
}

