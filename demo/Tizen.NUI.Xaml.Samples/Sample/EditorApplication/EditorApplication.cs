using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Examples
{
    internal class ViewBorder : View
    {
        internal void SetBindedView(View view)
        {
            bindedView = view;
            bindedView.Add(this);

            this.Size = view.Size;

            Show();
        }

        internal void DeleteBindedView()
        {
            if (bindedView is MaskView)
            {
                var maskView = bindedView as MaskView;
                bindedView = maskView.maskedView;

                bindedView.Remove(maskView);
                maskView.Dispose();
            }

            if (bindedView?.GetParent() != null)
            {
                bindedView.GetParent().Remove(bindedView);
            }

            bindedView?.Dispose();

            DisBindView();
        }

        internal void DisBindView()
        {
            bindedView?.Remove(this);
            bindedView = null;
            Hide();
        }

        internal new Size Size
        {
            get
            {
                return base.Size;
            }
            set
            {
                base.Size = value;
                bindedView.Size = value;
                Resize(value);
            }
        }

        internal new Position Position
        {
            get
            {
                return bindedView.Position;
            }
            set
            {
                bindedView.Position = value;
            }
        }

        private View bindedView;
        internal View BindedView
        {
            get
            {
                return bindedView;
            }
        }

        internal enum DragItemDirect
        {
            TOP_LEFT = 0,
            TOP,
            TOP_RIGHT,
            RIGHT,
            BOTTOM_RIGHT,
            BOTTOM,
            BOTTOM_LEFT,
            LEFT,
            MAX
        }

        private int dragItemSize = 8;

        internal class DragItem : View
        {
            internal DragItem(DragItemDirect dragItemDirect)
            {
                this.dragItemDirect = dragItemDirect;
                TouchEvent += DragItem_TouchEvent;
            }

            private bool DragItem_TouchEvent(object source, TouchEventArgs e)
            {
                return false;
            }

            internal DragItemDirect dragItemDirect;
        }

        private DragItem[] dragItems;

        private void Resize(Size size)
        {
            if (null == dragItems)
            {
                dragItems = new DragItem[(int)DragItemDirect.MAX];

                for (int i = 0; i < (int)DragItemDirect.MAX; i++)
                {
                    dragItems[i] = new DragItem((DragItemDirect)i);
                    dragItems[i].Size = new Size(dragItemSize, dragItemSize);
                    dragItems[i].BackgroundColor = Color.Yellow;
                    this.Add(dragItems[i]);
                }
            }

            dragItems[(int)DragItemDirect.TOP_LEFT].Position = new Position(-dragItemSize, -dragItemSize);
            dragItems[(int)DragItemDirect.TOP].Position = new Position((size.Width - dragItemSize) * 0.5f, -dragItemSize);
            dragItems[(int)DragItemDirect.TOP_RIGHT].Position = new Position(size.Width, -dragItemSize);

            dragItems[(int)DragItemDirect.LEFT].Position = new Position(-dragItemSize, (size.Height - dragItemSize) * 0.5f);

            dragItems[(int)DragItemDirect.BOTTOM_LEFT].Position = new Position(-dragItemSize, size.Height);
            dragItems[(int)DragItemDirect.BOTTOM].Position = new Position((size.Width - dragItemSize) * 0.5f, size.Height);
            dragItems[(int)DragItemDirect.BOTTOM_RIGHT].Position = new Position(size.Width, size.Height);

            dragItems[(int)DragItemDirect.RIGHT].Position = new Position(size.Width, (size.Height - dragItemSize) * 0.5f);
        }
    }

    internal class MaskView : View
    {
        internal MaskView(View maskedView, EditorApplication ownerApp) : base()
        {
            this.maskedView = maskedView;
            this.ownerApp = ownerApp;

            this.Size = this.maskedView.Size;
            this.BackgroundColor = Color.Transparent;
            maskedView.Add(this);

            this.TouchEvent += MaskView_TouchEvent;
            this.PropertyChanged += MaskView_PropertyChanged;
        }

        private void MaskView_PropertyChanged(object sender, global::System.ComponentModel.PropertyChangedEventArgs e)
        {
            if ("Position" == e.PropertyName)
            {
                if (0 != Position.X || 0 != Position.Y)
                {
                    var position = this.Position;
                    maskedView.Position += position;
                    this.Position = new Position(0, 0);
                }
            }
            else if ("Size" == e.PropertyName)
            {
                maskedView.Size = this.Size;
            }
        }

        private bool MaskView_TouchEvent(object source, TouchEventArgs e)
        {
            ownerApp.Root_TouchEvent(source, e);
            return true;
        }

        internal View maskedView;

        private EditorApplication ownerApp;
    }

    internal class DashedBox : ImageView
    {
        internal DashedBox(string url) : base(url)
        {
            Border = new Rectangle(45, 55, 110, 115);
            margin = new Extents(45, 55, 110, 115);
        }

        public new Position Position
        {
            get
            {
                return new Position(base.Position.X + margin.Start, base.Position.Y + margin.Top);
            }
            set
            {
                base.Position = new Position(value.X - margin.Start, value.Y - margin.End);
            }
        }

        public new Size Size
        {
            get
            {
                return new Size(base.Size.Width + margin.Start + margin.End, base.Size.Height + margin.Top + margin.End);
            }
            set
            {
                base.Size = new Size(value.Width + margin.Start + margin.End, value.Height + margin.Top + margin.End);
            }
        }

        private Extents margin;
    }

    public class EditorApplication : NUIApplication
    {
        static public Type SelectedType
        {
            get;
            set;
        }

        private enum Status
        {
            Normal,
            SelectingView,
            SelectingDragItem,
            DragingView,
            DragingDragItem,
            Selecting
        }

        private Status status;

        private View GetParentView(Container view)
        {
            var parent = view.GetParent();

            if (null == parent)
            {
                return null;
            }
            else
            {
                var parentView = parent as View;
                if (null == parentView)
                {
                    return GetParentView(parent);
                }
                else
                {
                    return parentView;
                }
            }
        }

        private Position GetAbsolutPosition(View view)
        {
            Position ret = new Position();

            while (null != view && root != view)
            {
                ret += view.Position;
                view = GetParentView(view);
            }

            return ret;
        }

        protected override void OnCreate()
        {
            base.OnCreate();
            Window window = Window.Instance;

            window.KeyEvent += Window_KeyEvent;

            root = new View();
            root.Size = window.Size;
            window.Add(root);

            //View view = new View();
            //view.Name = "TestView";
            //view.Size = new Size(300, 200);
            //view.Position = new Position(100, 100);
            //view.BackgroundColor = Color.Blue;
            //root.Add(view);

            borderOfSelectedView = new ViewBorder();
            borderOfSelectedView.Opacity = 0.3f;
            borderOfSelectedView.BackgroundColor = Color.Red;

            DashedBox = new DashedBox(@"G:\NUIControls\demo\Tizen.NUI.Xaml.Samples\res\image\Dashedbox.png");
            DashedBox.Hide();
            root.Add(DashedBox);

            root.TouchEvent += Root_TouchEvent;
        }

        protected void CoverAllView()
        {
            CoverView(root);
        }

        private void CoverView(View view)
        {
            if (view.IsCreateByXaml)
            {
                new MaskView(view, this);
            }

            foreach (var child in view.Children)
            {
                CoverView(child);
            }
        }

        private void Window_KeyEvent(object sender, Window.KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Up)
            {
                switch (e.Key.KeyCode)
                {
                    case '\r':
                        SelectedType = typeof(View);
                        break;

                    case 17: //Left ctrl
                        if (null != dragIntoView)
                        {
                            if (dragingView is MaskView)
                            {
                                var child = (dragingView as MaskView).maskedView;
                                View parent;

                                if (dragIntoView is MaskView)
                                {
                                    parent = (dragIntoView as MaskView).maskedView;
                                }
                                else
                                {
                                    parent = dragIntoView;
                                }

                                Position pos1 = GetAbsolutPosition(parent);
                                Position pos2 = GetAbsolutPosition(child);
                                child.Position = pos2 - pos1;
                                AddViewToView(child, parent);
                                dragIntoView = null;
                            }
                        }
                        break;

                    case 27: //Escape
                        if (null != borderOfSelectedView.BindedView)
                        {
                            borderOfSelectedView.DisBindView();
                        }
                        else
                        {
                            Window.Instance.Dispose();
                            //OnTerminate();
                            Exit();
                            Dispose();
                            //Window.Instance.Destroy();
                        }
                        break;

                    case 46:
                        DeleteSelectedView();
                        break;
                }
            }
        }

        internal bool Root_TouchEvent(object source, View.TouchEventArgs e)
        {
            var hitView = e.Touch.GetHitView(0);
            switch (e.Touch.GetState(0))
            {
                case PointStateType.Down:
                    if (root != hitView && null == EditorApplication.SelectedType && null == dragingView)
                    {
                        dragingView = hitView;

                        if (!(dragingView is ViewBorder.DragItem))
                        {
                            borderOfSelectedView.SetBindedView(hitView);
                        }
                    }
                    lastTouchPos = e.Touch.GetScreenPosition(0);
                    break;

                case PointStateType.Up:
                    dragingView = null;
                    dragIntoView = null;

                    var pos = e.Touch.GetScreenPosition(0);

                    if (null != SelectedType)
                    {
                        if (!(hitView is ViewBorder.DragItem))
                        {
                            if (hitView is MaskView)
                            {
                                CreateView(lastTouchPos, pos - lastTouchPos, (hitView as MaskView).maskedView);
                            }
                            else
                            {
                                CreateView(lastTouchPos, pos - lastTouchPos, hitView);
                            }
                        }
                    }

                    lastTouchPos = null;
                    SelectedType = null;
                    DashedBox.Hide();
                    break;

                case PointStateType.Motion:
                    Drag(e.Touch.GetScreenPosition(0));
                    break;
            }

            return true;
        }

        internal protected View root;
        private Type viewType = typeof(View);

        private ViewBorder borderOfSelectedView;

        private const int TopEdge = 18;

        private Vector2 lastTouchPos;

        private View dragingView;

        private View dragIntoView;

        private DashedBox DashedBox;

        private void Drag(Vector2 toPosition)
        {
            if (dragingView is ViewBorder.DragItem)
            {
                Vector4 mbrOfView = new Vector4();

                float xOffset = toPosition.X - lastTouchPos.X, yOffset = toPosition.Y - lastTouchPos.Y;

                switch ((dragingView as ViewBorder.DragItem).dragItemDirect)
                {
                    case ViewBorder.DragItemDirect.TOP_LEFT:
                        borderOfSelectedView.Position += new Position(xOffset, yOffset);
                        borderOfSelectedView.Size -= new Size(xOffset, yOffset);
                        break;

                    case ViewBorder.DragItemDirect.TOP:
                        borderOfSelectedView.Position += new Position(0, yOffset);
                        borderOfSelectedView.Size -= new Size(0, yOffset);
                        break;

                    case ViewBorder.DragItemDirect.TOP_RIGHT:
                        borderOfSelectedView.Position += new Position(0, yOffset);
                        borderOfSelectedView.Size += new Size(xOffset, -yOffset);
                        break;

                    case ViewBorder.DragItemDirect.LEFT:
                        borderOfSelectedView.Position += new Position(xOffset, 0);
                        borderOfSelectedView.Size -= new Size(xOffset, 0);
                        break;

                    case ViewBorder.DragItemDirect.RIGHT:
                        borderOfSelectedView.Size += new Size(xOffset, 0);
                        break;

                    case ViewBorder.DragItemDirect.BOTTOM_LEFT:
                        borderOfSelectedView.Position += new Position(xOffset, 0);
                        borderOfSelectedView.Size += new Size(-xOffset, yOffset);
                        break;

                    case ViewBorder.DragItemDirect.BOTTOM:
                        borderOfSelectedView.Size += new Size(0, yOffset);
                        break;

                    case ViewBorder.DragItemDirect.BOTTOM_RIGHT:
                        borderOfSelectedView.Size += new Size(xOffset, yOffset);
                        break;
                }

                lastTouchPos = toPosition;

                Console.WriteLine("Offset is ({0}, {1}), size is ({2}, {3})", xOffset, yOffset, borderOfSelectedView.Size.Width, borderOfSelectedView.Size.Height);
            }
            else if (null != dragingView)
            {
                if (borderOfSelectedView.BindedView == dragingView)
                {
                    borderOfSelectedView.Position += new Position(toPosition.X - lastTouchPos.X, toPosition.Y - lastTouchPos.Y);
                }
                else
                {
                    dragingView.Position += new Position(toPosition.X - lastTouchPos.X, toPosition.Y - lastTouchPos.Y);
                }

                lastTouchPos = toPosition;

                dragIntoView = GetAnotherHitView(new Position(toPosition.X, toPosition.Y), root, dragingView);
            }
            else
            {
                //Draw box to show the area of created view.
                if (null != SelectedType)
                {
                    if (false == DashedBox.Visibility)
                    {
                        DashedBox.RaiseToTop();
                        DashedBox.Show();
                        DashedBox.Position = new Position(lastTouchPos.X, lastTouchPos.Y);
                    }

                    DashedBox.Size = new Size(toPosition.X - lastTouchPos.X, toPosition.Y - lastTouchPos.Y);
                }
            }
        }

        private void CreateView(Vector2 position, Vector2 size, View hitView)
        {
            View view = Activator.CreateInstance(SelectedType) as View;

            if (null != view)
            {
                view.IsCreateByXaml = true;
                if (size.Width < 3 || size.Height < 3)
                {
                    view.Size = new Size(100, 60);
                }
                else
                {
                    view.Size = new Size(size.Width, size.Height);
                }

                AddViewToView(view, hitView);
                Vector4 color = hitView.BackgroundColor + new Color(0.3f, 0.3f, 0.3f, 1.0f);

                if (color.R > 1.0f)
                {
                    color.R -= 1.0f;
                }

                if (color.G > 1.0f)
                {
                    color.G -= 1.0f;
                }

                if (color.B > 1.0f)
                {
                    color.B -= 1.0f;
                }

                view.BackgroundColor = color;
                view.Position = ConvertWorldPositionToPosition(position, view);

                new MaskView(view, this);
            }
        }

        private void AddViewToView(View child, View parent)
        {
            parent.Add(child);
        }

        private Position ConvertWorldPositionToPosition(Vector2 worldPosition, View view)
        {
            Position position = new Position(worldPosition.X, worldPosition.Y);

            var parent = view.GetParent();

            while (parent != root)
            {
                if (parent is View)
                {
                    var parentView = parent as View;
                    position -= parentView.Position;
                }

                parent = parent.GetParent();
            }

            return position;
        }

        private void DeleteSelectedView()
        {
            borderOfSelectedView?.DeleteBindedView();
        }

        private View GetAnotherHitView(Position position, View view, View hitedView)
        {
            View ret = null;

            if (view != hitedView && !(view is ViewBorder.DragItem))
            {
                if (!(view is DashedBox)
                    &&
                    GetParentView(hitedView) != view
                    &&
                    GetParentView(view) != hitedView)
                {
                    if (0 <= position.X && 0 <= position.Y
                        &&
                        view.Size.Width >= position.X && view.Size.Height >= position.Y)
                    {
                        ret = view;
                    }
                }

                foreach (var child in view.Children)
                {
                    var tempRet = GetAnotherHitView(position - child.Position, child, hitedView);

                    if (null != tempRet)
                    {
                        ret = tempRet;
                        break;
                    }
                }
            }

            return ret;
        }
    }
}
