//
//  ZincAsBoxBase.cs
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
using ZincOxide.MiniZinc.Structures;

namespace ZincOxide.MiniZinc.Boxes {

	/// <summary>
	/// A basic implementation of the <see cref="IZincAsBox"/> interface that contains a <see cref="IZincAnnotations"/> instance.
	/// </summary>
	public class ZincAsBoxBase : ZincBoxBase, IZincAsBox { 						//TODO: make abstract
		private IZincAnnotations annotations;
		#region IZincExpressionBox implementation
		/// <summary>
		/// Gets the <see cref="IZincAnnotations"/> instance stored in the <see cref="IZincBox"/>.
		/// </summary>
		/// <value>
		/// The <see cref="IZincAnnotations"/> instance stored in the <see cref="IZincBox"/>.
		/// </value>
		public IZincAnnotations Annotations {
			get {
				return this.annotations;
			}
			protected set {
				this.annotations = value;
			}
		}
		#endregion
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="ZincAsBoxBase"/> class without an initial
		/// <see cref="Annotations"/> instance.
		/// </summary>
		protected ZincAsBoxBase () {
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ZincAsBoxBase"/> class with a given initial
		/// <see cref="Annotations"/> instance.
		/// </summary>
		/// <param name='annotations'>
		/// The initial <see cref="IZincAnnotations"/> instance to store.
		/// </param>
		protected ZincAsBoxBase (IZincAnnotations annotations) {
			this.Annotations = annotations;
		}
		#endregion
		#region IZincIdentReplaceContainer implementation
		/// <summary>
		/// Replaces all the instances stored in the given <see cref="T:IDictionary`2"/>
		/// stored as keys to the corresponding values and returns this instance.
		/// </summary>
		/// <param name='identMap'>
		/// A <see cref="T:IDictionary`2"/> that contains pairs if
		/// <see cref="IZincIdent"/> instances. The keys should be replaced by the values of the dictionary.
		/// </param>
		/// <returns>
		/// This instance, for cascading purposes.
		/// </returns>
		public override IZincIdentReplaceContainer Replace (IDictionary<IZincIdent, IZincIdent> identMap) {
			this.annotations = this.annotations.Replace (identMap) as ZincAnnotations;
			return this;
		}
		#endregion
		#region IComposition implementation
		/// <summary>
		/// Gets a list of involved <see cref="IZincElement"/> instances that are the children of
		/// this <see cref="IZincElement"/>.
		/// </summary>
		/// <returns>
		/// An <see cref="T:System.Collections.Generic.IEnumerable`1"/> instance of
		/// <see cref="IZincElement"/> that are the childrens of this <see cref="IZincBox"/> instance.
		/// </returns>
		public override IEnumerable<IZincElement> Children () {
			yield return this.annotations;
		}
		#endregion
	}
}

