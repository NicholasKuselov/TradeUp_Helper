   M S B A M L   `   `   `  ���� H  DTradeUpHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:TradeUpHelper.ViewsTradeUpHelper.Views  C&clr-namespace:TradeUpHelper.ViewModelsTradeUpHelper.ViewModels  )    #TradeUpHelper.Views.ChangeLogWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     3local!clr-namespace:TradeUpHelper.Views     Ishell9http://schemas.microsoft.com/netfx/2009/xaml/presentation    ;
viewmodels&clr-namespace:TradeUpHelper.ViewModels    -     � Title$  ChangeLogWindow��$	��300��$	��600�� � 
ResizeMode$ NoResize=� � WindowStyle$
 None=� � Topmost . ����  �� 
TargetType" �.��� '  !System.Windows.Shell.WindowChrome �� Property �@ WindowChrome �� Value      CaptionHeight$ 0Q�   CornerRadius$ 0��	   GlassFrameThickness$	 0,0,0,0q�
   NonClientFrameEdges$

 None=�   ResizeBorderThickness$ 5q�   UseAeroCaptionButtons .   � 	Resources  �� MergedDictionaries �� Source��  �� $1 +/Resources/Styles/WindowControlButtons.xaml?��� $) #/Resources/Styles/LabelsStyles.xaml?��� $, &/Resources/Styles/ListBoxesStyles.xaml?�%     � DataContext 0  *TradeUpHelper.ViewModels.ChangeLogWindowVM  .���� 
�������$��1q�._��  � RowDefinitions �� $��30 ��� $��* � � ColumnDefinitions �� $��* ��� $	��150 �.+�� $��0��$��0��$��2��   Color_WindowTopBar#���      
ExitButton �� 
TargetType  ExitIco2 �� Triggers P� Property P� Value �� 
TargetName # Color_WindowControlButtonsFocus % !Color_WindowControlButtonsPressed��%�   &	       �� " ��.R��� $��border��
������ ._��� #���  $��Center=�$��Center=� P�  �@J�IsMouseOver . . ��� $ border��# �   � ��P�  � �� . . ��� $ border��# �   � ��.+��� -   $��Right=�#��[ $��50����   
bChangeLog#���  $
��Left=�
�������� $��1��$��0��  Color_WindowBackground#���   �� $��30 ��� $��* �.+��� $��0�� �� ContentStringFormat$
 v{0}��$
��Left=�$��Center=�
�������$��16(����� *SelectedEntry.Version+�� -    ��Name$ sv_changeLog��$��1��$
��Auto=�.���� -   $��tb_changeLog��$��Stretch=�$��1��#���  
�������$��Stretch=���.  � UseLayoutRounding .  $
��Wrap=����� *SelectedEntry.Description+� $��1��$��1��  Color_lb_Background#���  .+��� $��1��$��Stretch=�$��Stretch=�$��Stretch=�  VersionLsbx#���   	 Color_lb_buttonBackground#��� 	 $��1,0,0,0q�
�������$��Disabled=� �� SelectedItem �� *SelectedEntry+���� *(&ChangeLogEntryHandler.changeLogEntries+