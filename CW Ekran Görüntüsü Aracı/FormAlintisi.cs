using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using WindowsHookLib;

namespace CW_Ekran_Görüntüsü_Aracı
{
    public partial class FormAlintisi : Form
    {
        private AnaForm referans_form = null;
        public AnaForm refForm
        {
            get
            {
                return referans_form;
            }
            set
            {
                referans_form = value;
            }
        }
        public FormAlintisi()
        {
            base.Paint += this.ObjectForm_Paint;
            base.Load += this.ObjectForm_Load;
            base.FormClosing += ObjectForm_FormClosing;
            this._objectRect = Rectangle.Empty;
            InitializeComponent();
        }
        private void ObjectForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.MouseHook.Dispose();
            this.KeyboardHook.Dispose();
        }
        internal virtual MouseHook MouseHook
        {
            [DebuggerNonUserCode]
            get
            {
                return this._MouseHook;
            }
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler<WindowsHookLib.MouseEventArgs> value2 = new EventHandler<WindowsHookLib.MouseEventArgs>(this.globalMouse_MouseMove);
                EventHandler<WindowsHookLib.MouseEventArgs> value3 = new EventHandler<WindowsHookLib.MouseEventArgs>(this.MouseHook_MouseDown);
                EventHandler<StateChangedEventArgs> value4 = new EventHandler<StateChangedEventArgs>(this.MouseHook_StateChanged);
                EventHandler<WindowsHookLib.MouseEventArgs> value5 = new EventHandler<WindowsHookLib.MouseEventArgs>(this.MouseHook_MouseUp);
                MouseEventHandler value6 = new MouseEventHandler(this.MouseHook_MouseClick);
                if (this._MouseHook != null)
                {
                    this._MouseHook.MouseMove -= value2;
                    this._MouseHook.MouseDown -= value3;
                    this._MouseHook.StateChanged -= value4;
                    this._MouseHook.MouseUp -= value5;
                    this._MouseHook.MouseClick -= value6;
                }
                this._MouseHook = value;
                if (this._MouseHook != null)
                {
                    this._MouseHook.MouseMove += value2;
                    this._MouseHook.MouseDown += value3;
                    this._MouseHook.StateChanged += value4;
                    this._MouseHook.MouseUp += value5;
                    this._MouseHook.MouseClick += value6;
                }
            }
        }
        internal virtual KeyboardHook KeyboardHook
        {
            [DebuggerNonUserCode]
            get
            {
                return this._KeyboardHook;
            }
            [DebuggerNonUserCode]
            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                EventHandler<KeyboardEventArgs> value2 = new EventHandler<KeyboardEventArgs>(this.KeyboardHook_KeyDown);
                EventHandler<StateChangedEventArgs> value3 = new EventHandler<StateChangedEventArgs>(this.KeyboardHook_StateChanged);
                EventHandler<KeyboardEventArgs> value4 = new EventHandler<KeyboardEventArgs>(this.KeyboardHook_KeyUp);
                bool flag = this._KeyboardHook != null;
                if (flag)
                {
                    this._KeyboardHook.KeyDown -= value2;
                    this._KeyboardHook.StateChanged -= value3;
                    this._KeyboardHook.KeyUp -= value4;
                }
                this._KeyboardHook = value;
                flag = (this._KeyboardHook != null);
                if (flag)
                {
                    this._KeyboardHook.KeyDown += value2;
                    this._KeyboardHook.StateChanged += value3;
                    this._KeyboardHook.KeyUp += value4;
                }
            }
        }
        private void KeyboardHook_StateChanged(object sender, StateChangedEventArgs e)
        {
            if (e.State == HookState.Uninstalled)
            {
            }
        }
        private void KeyboardHook_KeyDown(object sender, KeyboardEventArgs e)
        {
        }
        private void KeyboardHook_KeyUp(object sender, KeyboardEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                refForm.Show();
                refForm.Focus();
                this.Close();
            }
        }
        public Rectangle CaptureRect
        {
            get
            {
                return this._objectRect;
            }
        }
        private void ObjectForm_Load(object sender, EventArgs e)
        {
            this.refForm = (AnaForm)Owner;
            try
            {
                this.MouseHook.InstallHook();
                this.KeyboardHook.InstallHook();
            }
            catch (Exception ex)
            {
                this.Close();
                MessageBox.Show(ex.Message,"Hata");
            }
        }
        public void HookRemove()
        {
            try
            {
                HookState state = this.MouseHook.State;
                if (state == HookState.Installed)
                {
                    try
                    {
                        this.MouseHook.RemoveHook();
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Hata");
                    }
                }
            }
            catch { }
        }
        private void MouseHook_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && (e.X < this.refForm.Left || e.X > this.refForm.Bounds.Right || e.Y < this.refForm.Top || e.Y > this.refForm.Bounds.Bottom))
            {
                this.refForm.GoruntuyuYakala(false, CaptureRect);
                HookRemove();
            }
        }
        IntPtr intPtr;
        private void MouseHook_MouseDown(object sender, WindowsHookLib.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                e.Handled = (((sender != null) ? ((IntPtr)sender) : intPtr) != this.refForm.toolStrip1.Handle && ((sender != null) ? ((IntPtr)sender) : intPtr) != this.refForm.Handle);
            }
        }
        SCapture.Rect rect = default(SCapture.Rect);
        private void globalMouse_MouseMove(object sender, WindowsHookLib.MouseEventArgs e)
        {
            if (this.refForm.Handle != ((sender != null) ? ((IntPtr)sender) : intPtr) && this.refForm.toolStrip1.Handle != ((sender != null) ? ((IntPtr)sender) : intPtr))
            {
                if (((sender != null) ? ((IntPtr)sender) : intPtr) != IntPtr.Zero && this._object != ((sender != null) ? ((IntPtr)sender) : intPtr))
                {
                    this._object = ((sender != null) ? ((IntPtr)sender) : intPtr);
                    rect = default(SCapture.Rect);
                    if (SCapture.UnsafeNativeMethods.GetWindowRect(this._object, ref rect)) this._objectRect = rect.ToRectangle();
                    else this._objectRect = default(Rectangle);
                }
            }
            else
            {
                refForm.Focus();
                this._object = IntPtr.Zero;
            }
            this.Invalidate();
        }
        private void ObjectForm_Paint(object sender, PaintEventArgs e)
        {
            checked
            {
                if (this._object != IntPtr.Zero && !this._objectRect.IsEmpty)
                {
                    Rectangle objectRect = this._objectRect;
                    Graphics graphics = e.Graphics;
                    Pen pen = new Pen(Color.Red, 2f);
                    objectRect.Inflate((int)Math.Round((double)pen.Width), (int)Math.Round((double)pen.Width));
                    graphics.DrawRectangle(pen, objectRect);
                    pen.Dispose();
                }
            }
        }
        private void MouseHook_MouseUp(object sender, WindowsHookLib.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                e.Handled = (((sender != null) ? ((IntPtr)sender) : intPtr) != this.refForm.toolStrip1.Handle && ((sender != null) ? ((IntPtr)sender) : intPtr) != this.refForm.Handle);
            }
        }
        private void MouseHook_StateChanged(object sender, StateChangedEventArgs e)
        {
            if (e.State == HookState.Installed)
            {
            }
        }
    }
}
