﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18063
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SimpleDMS.Storage.Provider.LocalStorageProvider.Res {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Labels {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Labels() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("SimpleDMS.Storage.Provider.LocalStorageProvider.Res.Labels", typeof(Labels).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0}&apos;s document storage.
        /// </summary>
        internal static string DefaultStorageName {
            get {
                return ResourceManager.GetString("DefaultStorageName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to This provider creates archives on the local machine or in a local network mapped drive..
        /// </summary>
        internal static string ProviderDescription {
            get {
                return ResourceManager.GetString("ProviderDescription", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Save to local or network mapped drive.
        /// </summary>
        internal static string ProviderName {
            get {
                return ResourceManager.GetString("ProviderName", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to #.
        /// </summary>
        internal static string ProviderUrl {
            get {
                return ResourceManager.GetString("ProviderUrl", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to 0.1dev.
        /// </summary>
        internal static string ProviderVersion {
            get {
                return ResourceManager.GetString("ProviderVersion", resourceCulture);
            }
        }
    }
}
