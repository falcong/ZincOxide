//
//  ZincAnnotationItem.cs
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
using System.IO;
using ZincOxide.MiniZinc.Boxes;
using ZincOxide.MiniZinc.Structures;

namespace ZincOxide.MiniZinc.Items {

	/// <summary>
	/// A class representing an annotation item in a <see cref="IZincFile"/>. An annotation file contains
	/// an identifier such that the annotation of a certain item is explained by this identifier.
	/// </summary>
	public class ZincAnnotationItem : ZincIdBoxBase, IZincItem {

		#region IZincItem implementation
		/// <summary>
		/// Gets the type of the <see cref="IZincItem"/>.
		/// </summary>
		/// <value>The type of the <see cref="IZincItem"/>.</value>
		/// <remarks>
		/// <para>This property is mainly used to filter without the use
		/// of harmful object oriented structures and to prevent users from inventing more items.</para>
		/// <para>The type of a <see cref="ZincAnnotationItem"/> is <see cref="ZincItemType.Annotation"/>.</para>
		/// </remarks>
		public ZincItemType Type {
			get {
				return ZincItemType.Annotation;
			}
		}
		#endregion
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="ZincAnnotationItem"/> class with a given <see cref="IZincIdent"/>.
		/// that redirects to the semantic of the annotation.
		/// </summary>
		/// <param name="ident">An indentifier that links to the semantics of the identifier..</param>
		public ZincAnnotationItem (ZincIdent ident) : base(ident) {
		}
		#endregion
		#region ToString method
		/// <summary>
		/// Returns a <see cref="System.String"/> that represents the current <see cref="ZincAnnotationItem"/>.
		/// </summary>
		/// <returns>A <see cref="System.String"/> that represents the current <see cref="ZincAnnotationItem"/>.</returns>
		/// <remarks>
		/// <para>The format of this method is <c>annotation identifier foo</c> with identifier the identifier that links to the semantics of the annotation.</para>
		/// </remarks>
		public override string ToString () {
			return string.Format ("annotation {0} {1}", this.Ident, null);
		}
		#endregion
		#region IWriteable implementation
		/// <summary>
		/// Writes a textual representation of this <see cref="ZincAnnotationItem"/> to the given <see cref="TextWriter"/>.
		/// </summary>
		/// <param name="writer">The given <see cref="TextWriter"/> to write the content of this <see cref="ZincAnnotationItem"/> to.</param>
		public void Write (TextWriter writer) {
			writer.Write (this.ToString ());
		}
		#endregion
	}
}

