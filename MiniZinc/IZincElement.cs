//
//  IZincElement.cs
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
using ZincOxide.Utils;
using ZincOxide.MiniZinc.Structures;

namespace ZincOxide.MiniZinc {

	/// <summary>
	/// An interface describing an element in the Zinc language. An element can be anything and is organized as a composite pattern.
	/// </summary>
	/// <remarks>
	/// <para>Zinc elements have (sometimes zero) children, can be validated and can contain identifiers that can be replaced with
	/// other Zinc elements.</para>
	/// <para>This interface is a currently a "sign" interface.</para>
	/// </remarks>
	public interface IZincElement : IInnerSoftValidateable, ISoftValidateable, IComposition<IZincElement>, IZincIdentReplaceContainer {
	}
}

