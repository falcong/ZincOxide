//
//  ZincNameRegister.cs
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
using ZincOxide.Exceptions;
using ZincOxide.Utils.Nameregister;

namespace ZincOxide.MiniZinc.Structures {

	/// <summary>
	/// A registrar for identifiers. Used to store identifiers. The registrar has a fallback mechanism
	/// as well such that cascading scopes are possible.
	/// </summary>
	public class ZincIdentNameRegister : GenerateFallbackNameRegister<IZincIdent> {

		#region Fields
		private ZincIdentNameRegister parent;
		#endregion
		#region Properties
		/// <summary>
		/// Gets or sets the name register of the parent scope, if the scope has no parent (e.g. the root scope), the
		/// value is not effective.
		/// </summary>
		/// <value>The name register of the parent scope.</value>
		public ZincIdentNameRegister Parent {
			get {
				return this.parent;
			}
			set {
				this.parent = value;
			}
		}
		#endregion
		#region Constructors
		/// <summary>
		/// Initializes a new instance of the <see cref="ZincIdentNameRegister"/> class with a given optional parent
		/// name register.
		/// </summary>
		/// <param name="parent">The parent name register, optional, by default <c>null</c>.</param>
		public ZincIdentNameRegister (ZincIdentNameRegister parent = null) : base (null, x => new ZincIdent (x)) {
			this.Parent = parent;
			this.Fallback = checkUpperNameRegister;
		}
		#endregion
		#region Fallback implementation
		/// <summary>
		/// The representation of the fallback mechanism: it takes into account the parent scope name register.
		/// </summary>
		/// <returns>The identifier according to the parent scope (or cascading).</returns>
		/// <param name="name">The name that should be looked up.</param>
		private IZincIdent checkUpperNameRegister (string name) {
			if (this.parent != null) {
				return this.parent.Lookup (name);
			} else {
				throw new ZincOxideNameNotFoundException ("No upper scope contains \"{0}\".", name);
			}
		}
		#endregion
	}
}