   M S B A M L   `   `   `  ����H  DTradeUpHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:TradeUpHelper.ViewsTradeUpHelper.Views  5   	   C&clr-namespace:TradeUpHelper.ViewModelsTradeUpHelper.ViewModels  5   Q   )    #TradeUpHelper.Views.ChangeLogWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:TradeUpHelper.Views     5   	   Ishell9http://schemas.microsoft.com/netfx/2009/xaml/presentation    5   	   ;
viewmodels&clr-namespace:TradeUpHelper.ViewModels    6Q   -   5          � Title$  ChangeLogWindow��5	   	   $	��300��6!   $	��600��6.    � 
ResizeMode$ NoResize=�6:    � WindowStyle$
 None=�6P    � Topmost . ��5      �� 5   
    �� 
TargetType" �6   .�5      �� '  !System.Windows.Shell.WindowChrome �� Property �@ WindowChrome �� Value 5        5         CaptionHeight$ 0Q�6)      CornerRadius$ 0��5   )   	   GlassFrameThickness$	 0,0,0,0q�5   )   
   NonClientFrameEdges$

 None=�5   )      ResizeBorderThickness$ 5q�5   )      UseAeroCaptionButtons .  5   )   5      5       � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $1 +/Resources/Styles/WindowControlButtons.xaml?�6%   �� 5      $) #/Resources/Styles/LabelsStyles.xaml?�6%   �� 5       $, &/Resources/Styles/ListBoxesStyles.xaml?�6%   %    5"       � DataContext 5%      0  *TradeUpHelper.ViewModels.ChangeLogWindowVM  5&   
   .��5*      �� 
�������$��1q�6%   ._�5+   
   �  � RowDefinitions 5,      �� 5-      $��30 �6    �� 5.      $��* �6     � ColumnDefinitions 50      �� 51      $��* �6#   �� 52      $	��150 �6#   .+�54      � $��0��6   $��0��6    $��2��60      Color_WindowTopBar#���   6D    55        
ExitButton �� 
TargetType  ExitIco2 �� Triggers P� Property P� Value �� 
TargetName # Color_WindowControlButtonsFocus % !Color_WindowControlButtonsPressed��%�  &	       �� 56      " ��69   .R�57      �� $��border��6#   
������ ._�58      �� #���  6/   $��Center=�6T   $��Center=�6q   59       5:      P� 5;       �@J�IsMouseOver . . �5<   "   �� $ border��6)   # �  6S    � ��6�   5=      P� 5>       � �� . . �5?   "   �� $ border��6)   # �  6S    � ��6�   5@      5B      5C      .+�5D      �� -   5        $��Right=�5D      #��[ 65   $��50��6\   6g   �� 5E        
bChangeLog#���  6   $
��Left=�6?   
�������6Z   5F      � 5H      $��1��6   $��0��6      Color_WindowBackground#���  60    5I      �� 5J      $��30 �6$   �� 5K      $��* �6$   .+�5M      �� $��0��6    �� ContentStringFormat$
 v{0}��6P   $
��Left=�6k   $��Center=�6�   
�������$��16(�6�   ��6%   �� *SelectedEntry.Version+6�   �� 5N      -   5         ��Name$ sv_changeLog��5N      $��1��65   $
��Auto=�6B   .��5O      �� -   5        $��tb_changeLog��5O   �   $��Stretch=�6    $��1��6i   #���  6v   
�������$��Stretch=�6�   ��.  � UseLayoutRounding .  $
��Wrap=�6.  ��6>   �� *SelectedEntry.Description+6.  5P      5Q      � 5T      $��1��6   $��1��6      Color_lb_Background#���  60   .+�5U      �� $��1��6   $��Stretch=�6O   $��Stretch=�6�   $��Stretch=�6�     VersionLsbx#���  6�    	 Color_lb_buttonBackground#��� 	 6   $��1,0,0,0q�6Y  
�������$��Disabled=�6�   �� SelectedItem 6(   �� *SelectedEntry+��6m   �� *(&ChangeLogEntryHandler.changeLogEntries+6�  5W      5X      5Y      5Z      