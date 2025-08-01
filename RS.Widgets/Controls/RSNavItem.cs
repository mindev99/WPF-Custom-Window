﻿using RS.Widgets.Enums;
using RS.Widgets.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace RS.Widgets.Controls
{
    public class RSNavItem : ListBoxItem
    {
        public RSNavItem()
        {

        }

        protected override void OnPreviewMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnPreviewMouseLeftButtonDown(e);
            this.OnNavItemClick();
        }
        private void OnNavItemClick()
        {
            var rsNavigate = this.GetNavigate();
            if (rsNavigate == null)
            {
                return;
            }

            var navigateModel = this.DataContext as NavigateModel;
            if (navigateModel == null)
            {
                return;
            }

            if (navigateModel.IsGroupNav)
            {
                return;
            }

            rsNavigate.UpdateNavigateModelSelect(navigateModel);



            if (!rsNavigate.IsNavExpanded)
            {
                //级联删除
                var rsNavMenuParent = this.TryFindParent<RSNavPopup>();
                rsNavMenuParent?.CascadingDestroy(CascadeDeleteDirection.Both);
                //如果选中 则展开父级
                rsNavMenuParent?.ExpandParentNav();
            }



            this.RaiseEvent(new RoutedEventArgs()
            {
                RoutedEvent = RSNavigate.NavItemClickEvent,
                Source = navigateModel
            });

            if (rsNavigate.NavItemClickCommand != null)
            {
                rsNavigate.NavItemClickCommand.Execute(navigateModel);
            }
        }

        protected override void OnMouseEnter(MouseEventArgs e)
        {
            base.OnMouseEnter(e);
            this.OnNavItemHover();
        }

        private void OnNavItemHover()
        {
            var parentWin = this.TryFindParent<Window>();
            parentWin?.Activate();


            var navigateModel = this.DataContext as NavigateModel;
            if (navigateModel == null)
            {
                return;
            }
            if (!string.IsNullOrEmpty(navigateModel.ParentId))
            {
                this.ShowRSNavPopup(navigateModel);
            }
        }

        private void ShowRSNavPopup(NavigateModel navigateModel)
        {
            var rsNavigate = this.GetNavigate();
            if (rsNavigate == null)
            {
                return;
            }
            if (!rsNavigate.IsNavExpanded)
            {
                var subChildren = rsNavigate.ItemsSource.Where(t => t.ParentId == navigateModel.Id).ToList();
                if (subChildren.Count > 0)
                {
                    var parentNavList = this.TryFindParent<RSNavList>();
                    //级联向下关闭所有弹出
                    parentNavList.RSNavPopup?.CascadingDestroy(CascadeDeleteDirection.Down);
                    var rsNavMenuParent = this.TryFindParent<RSNavPopup>();
                    parentNavList.RSNavPopup = new RSNavPopup(rsNavigate, rsNavMenuParent, this, subChildren);
                    parentNavList.RSNavPopup.Show();
                }
            }


        }

        private RSNavigate? GetNavigate()
        {
            var rsNavigate = this.TryFindParent<RSNavigate>();
            if (rsNavigate == null)
            {
                var rsNavMenu = this.TryFindParent<RSNavPopup>();
                rsNavigate = rsNavMenu?.RSNavigate;
            }

            return rsNavigate;
        }

        protected override void OnPreviewMouseDoubleClick(MouseButtonEventArgs e)
        {
            base.OnPreviewMouseDoubleClick(e);
            this.OnNavItemDoubleClick();
        }

        private void OnNavItemDoubleClick()
        {
            var rsNavigate = this.GetNavigate();
            if (rsNavigate == null)
            {
                return;
            }
            var navigateModel = this.DataContext as NavigateModel;
            if (navigateModel == null)
            {
                return;
            }

            if (navigateModel.IsGroupNav)
            {
                return;
            }

            if (rsNavigate.IsNavExpanded)
            {
                if (navigateModel != null)
                {
                    navigateModel.IsExpand = !navigateModel.IsExpand;
                }
                rsNavigate.UpdateNavigateModelList();
            }
            else
            {
                this.ShowRSNavPopup(navigateModel);
            }


            rsNavigate.RaiseEvent(new RoutedEventArgs()
            {
                RoutedEvent = RSNavigate.NavItemDoubleClickEvent,
                Source = navigateModel
            });
            if (rsNavigate.NavItemDoubleClickCommand != null)
            {
                rsNavigate.NavItemDoubleClickCommand.Execute(navigateModel);
            }
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
        }
    }
}
