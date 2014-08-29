//
//  IClass.cs
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
using System.Collections.Generic;
using ZincOxide.Utils.Abstract;
using System.Diagnostics.Contracts;

namespace ZincOxide.Codegen.Abstract.OO {

	/// <summary>
	/// An interface describing a language-invariant class: a description of a group of instances.
	/// </summary>
	[ContractClass(typeof(ClassContract))]
	public interface IClass : IType {

		/// <summary>
		/// Generate a field contained in this class.
		/// </summary>
		/// <param name='type'>The type of the field.</param>
		/// <param name='name'>The name of the field to be added.</param>
		/// <returns>A <see cref="IField"/> instance describing the generated field.</returns>
		IField GenerateField (IType type, string name);

		/// <summary>
		/// Generate a method contained in this class.
		/// </summary>
		/// <returns>A <see cref="IMethod"/> that represents the generated method and can be altered.</returns>
		/// <param name="returnType">A <see cref="IType"/> that specifies the return type of the method, <c>null</c> if the return type is <c>void</c> (or irrelevant).</param>
		/// <param name="name">The name of the method to be generated.</param>
		/// <param name="fields">A list of parameters that should be defined by the method.</param>
		IMethod GenerateMethod (IType returnType, string name, params IType[] fields);

		/// <summary>
		/// Generate a method contained in this class that returns nothing, or where the return data is irrelevant.
		/// </summary>
		/// <returns>A <see cref="IMethod"/> that represents the generated method and can be altered.</returns>
		/// <param name="name">The name of the method to be generated.</param>
		/// <param name="fields">A list of parameters that should be defined by the method.</param>
		IMethod GenerateMethod (string name, params IType[] fields);

		/// <summary>
		/// Add a public constructor to the class that instantiates the given fields.
		/// </summary>
		/// <param name="modifiers">A modifier value that specifies how the constructor should be implemented, optional, by default public access.</param>
		/// <param name="fields">A list of fields that are all instantiated by the constructor.</param>
		/// <remarks>
		/// <para>The order of the constructor parameters is the same as the order of the given list.</para>
		/// <para>Fields not belonging to the class, not effective of from the wrong type are ignored.</para>
		/// <para>The constructor simply sets the fields to the given value, no consistency checks are performed.</para>
		/// </remarks>
		void AddConstructor (OOModifiers modifiers = OOModifiers.Public, params IField[] fields);

		/// <summary>
		/// Add a public constructor to the class that instantiates the given fields.
		/// </summary>
		/// <param name="fields">A list of fields that are all instantiated by the constructor.</param>
		/// <param name="modifiers">A modifier value that specifies how the constructor should be implemented.</param>
		/// <remarks>
		/// <para>The order of the constructor parameters is the same as the order of the given list.</para>
		/// <para>Fields not belonging to the class, not effective of from the wrong type are ignored.</para>
		/// <para>The constructor simply sets the fields to the given value, no consistency checks are performed.</para>
		/// </remarks>
		void AddConstructor (IEnumerable<IField> fields, OOModifiers modifiers = OOModifiers.Public);

		/// <summary>
		/// Add a constructor to the class where all fields are included as parameters.
		/// </summary>
		/// <param name="modifiers">A modifier value that specifies how the constructor should be implemented.</param>
		/// <remarks>
		/// <para>The order is determined by the order in which fields were added to the class.</para>
		/// <para>The constructor simply sets the fields to the given value, no consistency checks are performed.</para>
		/// <para>This method is not declarative: adding fields to the class after calling this method
		/// will not modify the constructor.</para>
		/// </remarks>
		void AddFieldConstructor (OOModifiers modifiers = OOModifiers.Public);
	}
}

