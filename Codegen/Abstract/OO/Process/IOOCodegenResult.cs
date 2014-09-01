//
//  ICodeResult.cs
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
using ZincOxide.Environment;

namespace ZincOxide.Codegen.Abstract.OO.Process {

	/// <summary>
	/// An interface describing the result of the code generator (language invariant) according to the
	/// object-oriented programming paradigm.
	/// </summary>
	[ContractClass(typeof(OOCodegenResultContract))]
	public interface IOOCodegenResult : ICodegenResult {

		/// <summary>
		/// Generate a class with the given name.
		/// </summary>
		/// <param name="name">The name of the class that must be generated/returned.</param>
		/// <returns>A <see cref="IClass"/> instance that represents the generated class.</returns>
		/// <remarks>
		/// <para>The name is prefixed with the <see cref="P:ICodegenEnvironment.ClassPrefix"/> name automatically.</para>
		/// </remarks>
		IClass GenerateClass (string name);

		/// <summary>
		/// Get the type that corresponds with the integer representation type of the environment.
		/// </summary>
		/// <returns>A <see cref="IType"/> that corresponds with the integer representation type of the environment.</returns>
		IType GetIntegerType ();

		/// <summary>
		/// Get the type that corresponds with the float representation type of the environment.
		/// </summary>
		/// <returns>A <see cref="IType"/> that corresponds with the float representation type of the environment.</returns>
		IType GetFloatType ();

		/// <summary>
		/// Get the type used to represent a boolean.
		/// </summary>
		/// <returns>A <see cref="IType"/> that represents the boolean type.</returns>
		IType GetBooleanType ();

		/// <summary>
		/// Get the type that corresponds with the given integer representation (abstract) type for the specific language.
		/// </summary>
		/// <returns>A <see cref="IType"/> that corresponds to the given integer representation type.</returns>
		/// <param name="pir">The given integer representation type.</param>
		IType GetIntegerType (ProgramIntegerRepresentation pir);

		/// <summary>
		/// Get the type that corresponds with the given float representation (abstract) type for the specific language.
		/// </summary>
		/// <returns>A <see cref="IType"/> that corresponds to the given float representation type.</returns>
		/// <param name="pfr">The given float representation type.</param>
		IType GetFloatType (ProgramFloatRepresentation pfr);

		/// <summary>
		/// Get the type that corresponds with a string builder.
		/// </summary>
		/// <returns>A <see cref="IType"/> that corresponds with the programming language string builder type.</returns>
		/// <remarks>
		/// <para>A string builder is a class that enables fast string generation where appending
		/// takes at most linear time in the length of the string to append and not in the length
		/// of the resulting string.</para>
		/// </remarks>
		IType GetStringBuilderType ();
	}
}