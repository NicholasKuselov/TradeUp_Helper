   M S B A M L   `   `   `  ����H  DTradeUpHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:TradeUpHelper.ViewsTradeUpHelper.Views  5   	   )    #TradeUpHelper.Views.ChangeLogWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:TradeUpHelper.Views     5   	   Ishell9http://schemas.microsoft.com/netfx/2009/xaml/presentation    5   	   -   5          � Title$  ChangeLogWindow��5	   	   $	��300��6!   $	��600��6.    � 
ResizeMode$ NoResize=�6:    � WindowStyle$
 None=�6P    � Topmost . ��5      �� 5   
    �� 
TargetType" �6   .�5      �� '  !System.Windows.Shell.WindowChrome �� Property �@ WindowChrome �� Value 5        5         CaptionHeight$ 0Q�6)      CornerRadius$ 0��5   )   	   GlassFrameThickness$	 0,0,0,0q�5   )   
   NonClientFrameEdges$

 None=�5   )      ResizeBorderThickness$ 5q�5   )      UseAeroCaptionButtons .  5   )   5      5      .��5      �� 
�������$��1q�6%   ._�5      �  � RowDefinitions 5   
   �� 5      $��30 �6   �� 5      $��* �6   .+�5       � $��0��6      Color_WindowTopBar#���   6     � 	Resources 5!        
ExitButton �� 
TargetType  ExitIco2 �� Triggers P� Property P� Value �� 
TargetName # Color_WindowControlButtonsFocus % !Color_WindowControlButtonsPressed��%�  &	       �� 5"      " ��69   .R�5#      �� $��border��6#   
������ ._�5$      �� #���  6/   $��Center=�6T   $��Center=�6q   5%       5&      P� 5'       �@J�IsMouseOver . . �5(   "   �� $ border��6)   # �  6S    � ��6�   5)      P� 5*       � �� . . �5+   "   �� $ border��6)   # �  6S    � ��6�   5,      5.      5/      .+�50      �� -   5        $��Right=�50      #��[ 65   $��50��6\   6g   �� 51        
bChangeLog#���  6   $
��Left=�6?   
�������6Z   52      �� 53      -   5         ��Name$ sv_changeLog��53      $��1��61   $
��Auto=�6>   .��54      �� -   5        $��tb_changeLog��54   ~   $��Stretch=�6   $��1��6;     Color_WindowBackground#���  6H   
�������$��Stretch=�6�   ��.  � UseLayoutRounding .  $
��Wrap=�6   55      57      58      59      