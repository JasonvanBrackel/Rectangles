﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18034
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace vanBrackel.Rectangles.Domain {
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
    public class vanBrackel_Rectangles_Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal vanBrackel_Rectangles_Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("vanBrackel.Rectangles.Domain.vanBrackel.Rectangles.Resources", typeof(vanBrackel_Rectangles_Resources).Assembly);
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
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The coordinates provided will not create the shape requested..
        /// </summary>
        public static string BadShapeError {
            get {
                return ResourceManager.GetString("BadShapeError", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Container service must be initialized with an instance of IRectangle.
        /// </summary>
        public static string ContainmentServiceNotInitializedMessage {
            get {
                return ResourceManager.GetString("ContainmentServiceNotInitializedMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Rectangles are adjacent..
        /// </summary>
        public static string IsAdjacentMessage {
            get {
                return ResourceManager.GetString("IsAdjacentMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Rectangles intersect at points {0}..
        /// </summary>
        public static string IsAnIntersectionMessage {
            get {
                return ResourceManager.GetString("IsAnIntersectionMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Rectangle {0} is contained in Rectangle {1}..
        /// </summary>
        public static string IsContainedInMessage {
            get {
                return ResourceManager.GetString("IsContainedInMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Rectangles are not adjacent..
        /// </summary>
        public static string IsNotAdjacentMessage {
            get {
                return ResourceManager.GetString("IsNotAdjacentMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Rectangles do not intersect..
        /// </summary>
        public static string IsNotAnIntersectionMessage {
            get {
                return ResourceManager.GetString("IsNotAnIntersectionMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Neither rectangle contains the other..
        /// </summary>
        public static string IsNotContainedMessage {
            get {
                return ResourceManager.GetString("IsNotContainedMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Shapes are not comparable..
        /// </summary>
        public static string NotComparableMessage {
            get {
                return ResourceManager.GetString("NotComparableMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Lines are the same and cannot be compared..
        /// </summary>
        public static string SameLinesErrorMessage {
            get {
                return ResourceManager.GetString("SameLinesErrorMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Rectangles are the same and cannot be compared..
        /// </summary>
        public static string SameRectanglesErrorMessage {
            get {
                return ResourceManager.GetString("SameRectanglesErrorMessage", resourceCulture);
            }
        }
    }
}
