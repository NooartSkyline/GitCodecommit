using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace CheckBox
{	
	/// <summary>
	/// CheckBoxCell is the Cell for displaying the boolean values checkbox like. 
	/// We derive from ImageCell and will supply the Image to draw with overriden GetImage method.
	/// </summary>
	class CheckBoxCell   : Resco.Controls.AdvancedList.ImageCell
	{
		static Image CheckBoxImage = null;

		public CheckBoxCell()
		{
			// set up some default properties for base Cell
			base.Border = Resco.Controls.AdvancedList.BorderType.Flat;
			base.BackColor = Color.White;
			if (CheckBoxImage == null)
			{
                //System.IO.Stream strm = null;
                //strm = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("DoHome.HandHeld.Client.Images.cb_check.bmp");
                //CheckBoxImage = new Bitmap(strm);
                CheckBoxImage = DoHome.HandHeld.Client.Properties.Resources.cb_check;
			}
			base.AutoResize = true;
		}
		public CheckBoxCell(CheckBoxCell cell)
			: base(cell)
		{
			// copy constructor for Clone method, ImageCell copy constructor will handle the details 
		}

		public override Resco.Controls.AdvancedList.Cell Clone()
		{
			// we must override this to Clone derived cells properly
			return new CheckBoxCell(this);
		}

		protected override Image GetImage(object data)
		{
			// here is the important method for ImageCell
			// Image cell will draw the returned Image, handles also sizing and placement

			if (data is bool && (bool)data)
				return CheckBoxCell.CheckBoxImage;	// checkmark is drawn

			return null;	// when null is returned, only background and border is drawn
		}

		// override border to be always drawn -> CheckBox frame
		public override Resco.Controls.AdvancedList.BorderType Border
		{
			get
			{
				return Resco.Controls.AdvancedList.BorderType.Flat;
			}
			set
			{
			}
		}
		// override BackColor to be always White -> CheckBox interior
		public override Color BackColor
		{
			get
			{
				return Color.White;
			}
			set
			{
			}
		}
	}
}
