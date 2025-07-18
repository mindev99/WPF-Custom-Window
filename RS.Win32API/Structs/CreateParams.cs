﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RS.Win32API.Structs
{
    public class CreateParams
    {
        string className;
        string caption;
        int style;
        int exStyle;
        int classStyle;
        int x;
        int y;
        int width;
        int height;
        IntPtr parent;
        object param;

        /// <devdoc>
        ///     Name of the window class to subclass. The default value for this field
        ///     is null, indicating that the window is not a subclass of an existing
        ///     window class. To subclass an existing window class, store the window
        ///     class name in this field. For example, to subclass the standard edit
        ///     control, set this field to "EDIT".
        /// </devdoc>
        public string ClassName
        {
            get { return className; }
            set { className = value; }
        }

        /// <devdoc>
        ///     The initial caption your control will have.
        /// </devdoc>
        public string Caption
        {
            get { return caption; }
            set { caption = value; }
        }

        /// <devdoc>
        ///     Window style bits. This must be a combination of WS_XXX style flags and
        ///     other control-specific style flags.
        /// </devdoc>
        public int Style
        {
            get { return style; }
            set { style = value; }
        }

        /// <devdoc>
        ///     Extended window style bits. This must be a combination of WS_EX_XXX
        ///     style flags.
        /// </devdoc>
        public int ExStyle
        {
            get { return exStyle; }
            set { exStyle = value; }
        }

        /// <devdoc>
        ///     Class style bits. This must be a combination of CS_XXX style flags. This
        ///     field is ignored if the className field is not null.
        /// </devdoc>
        public int ClassStyle
        {
            get { return classStyle; }
            set { classStyle = value; }
        }

        /// <devdoc>
        ///     The left portion of the initial proposed location.
        /// </devdoc>
        public int X
        {
            get { return x; }
            set { x = value; }
        }

        /// <devdoc>
        ///     The top portion of the initial proposed location.
        /// </devdoc>
        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        /// <devdoc>
        ///     The initially proposed width.
        /// </devdoc>
        public int Width
        {
            get { return width; }
            set { width = value; }
        }

        /// <devdoc>
        ///     The initially proposed height.
        /// </devdoc>
        public int Height
        {
            get { return height; }
            set { height = value; }
        }

        /// <devdoc>
        ///     The controls parent.
        /// </devdoc>
        public IntPtr Parent
        {
            get { return parent; }
            set { parent = value; }
        }

        /// <devdoc>
        ///     Any extra information that the underlying handle might want.
        /// </devdoc>
        public object Param
        {
            get { return param; }
            set { param = value; }
        }

        /// <devdoc>
        ///    <para>[To be supplied.]</para>
        /// </devdoc>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(64);
            sb.Append("CreateParams {'");
            sb.Append(className);
            sb.Append("', '");
            sb.Append(caption);
            sb.Append("', 0x");
            sb.Append(Convert.ToString(style, 16));
            sb.Append(", 0x");
            sb.Append(Convert.ToString(exStyle, 16));
            sb.Append(", {");
            sb.Append(x);
            sb.Append(", ");
            sb.Append(y);
            sb.Append(", ");
            sb.Append(width);
            sb.Append(", ");
            sb.Append(height);
            sb.Append("}");
            sb.Append("}");
            return sb.ToString();
        }
    }
}
