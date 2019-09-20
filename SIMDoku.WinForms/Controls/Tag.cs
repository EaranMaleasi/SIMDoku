using SIMDoku.Messaging;

using System;
using System.Drawing;
using System.Windows.Forms;

namespace SIMDoku.WinForms.Controls
{
	public partial class Tag : Panel, IDisposable
	{
		public Guid TagID { get; }
		private IMessagingCenter _Messaging;

		public string TagText { get; set; }

		private float _CrossThickness;

		private Point _Location;
		private Color _CrossColor;

		private PointF _CrossTopLeft;
		private PointF _CrossTopRight;
		private PointF _CrossBottomLeft;
		private PointF _CrossBottomRight;

		private Pen _CrossPen;

		private float _ButtonSize;
		private RectangleF _ButtonRectangle;

		private Color _ButtonColor;
		private Brush _ButtonBrush;

		public float ButtonSize
		{
			get => _ButtonSize;
			set
			{
				_ButtonSize = value;
				_ButtonRectangle = new RectangleF(_Location, new SizeF(_ButtonSize, _ButtonSize));
				CalculateCrossPoints();
				Invalidate();
			}
		}

		public Color CrossColor
		{
			get => _CrossColor;
			set
			{
				_CrossColor = value;
				_CrossPen.Color = _CrossColor;
				Invalidate();
			}
		}
		public Color ButtonColor
		{
			get => _ButtonColor;
			set
			{
				_ButtonColor = value;
				_ButtonBrush?.Dispose();
				_ButtonBrush = new SolidBrush(_ButtonColor);
				Invalidate();
			}
		}

		public float CrossThickness
		{
			get => _CrossThickness;
			set
			{
				_CrossThickness = value;
				_CrossPen.Width = _CrossThickness;
				Invalidate();
			}
		}

		public Point ButtonLocation
		{
			get => _Location;
			set
			{
				_Location = value;
				_ButtonRectangle = new RectangleF(_Location, new SizeF(_ButtonSize, _ButtonSize));
				CalculateCrossPoints();
				Invalidate();
			}
		}

		public Tag()
		{
			InitializeComponent();
			TagID = Guid.NewGuid();

			_CrossPen = new Pen(Color.White, 1.5f);
			ButtonSize = Height - 4f;
			ButtonColor = Color.DarkGray;


			ButtonLocation = new Point(2, 2);
		}

		public Tag(IMessagingCenter messagingCenter) : this()
		{
			_Messaging = messagingCenter;
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			Graphics graphics = e.Graphics;
			graphics.Clear(SystemColors.Control);

			DrawCloseButton(e.Graphics);

			SizeF stringSize = graphics.MeasureString("Test", new Font(FontFamily.GenericSansSerif, 1));

		}

		private void CalculateCrossPoints()
		{
			float pointTopRightCircleY = Location.Y + _ButtonSize / 4;
			float pointTopRightCircleX = Location.X + _ButtonSize / 4 * 3;

			float pointTopLeftCircleY = Location.Y + _ButtonSize / 4;
			float pointTopLeftCircleX = Location.X + _ButtonSize / 4;

			float pointBottomLeftCircleY = Location.Y + _ButtonSize / 4 * 3;
			float pointBottomLeftCircleX = Location.X + _ButtonSize / 4;

			float pointBottomRightCircleY = Location.Y + _ButtonSize / 4 * 3;
			float pointBottomRightCircleX = Location.X + _ButtonSize / 4 * 3;



			_CrossTopLeft = new PointF(pointTopLeftCircleX, pointTopLeftCircleY);
			_CrossTopRight = new PointF(pointTopRightCircleX, pointTopRightCircleY);
			_CrossBottomLeft = new PointF(pointBottomLeftCircleX, pointBottomLeftCircleY);
			_CrossBottomRight = new PointF(pointBottomRightCircleX, pointBottomRightCircleY);
		}

		public void DrawCloseButton(Graphics graphics)
		{
			graphics.FillEllipse(Brushes.LightGray, _ButtonRectangle);

			graphics.DrawLine(_CrossPen, _CrossTopLeft, _CrossBottomRight);
			graphics.DrawLine(_CrossPen, _CrossBottomLeft, _CrossTopRight);
		}

		protected override void OnMouseClick(MouseEventArgs e)
		{
			base.OnMouseClick(e);
			if (e.Button != MouseButtons.Left)
			{
				return;
			}
			if (CloseClicked(e))
			{
				_Messaging?.SendMessage(Messages.TAG_CLOSE_CLICKED, TagID);
			}
		}

		public bool CloseClicked(MouseEventArgs e)
		{
			return _ButtonRectangle.Contains(e.Location);
		}

		public new void Dispose()
		{
			_CrossPen.Dispose();
			_ButtonBrush?.Dispose();
			base.Dispose();
		}
	}
}
