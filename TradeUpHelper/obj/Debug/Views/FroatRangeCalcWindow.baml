   M S B A M L   `   `   `  ����H  DTradeUpHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:TradeUpHelper.ViewsTradeUpHelper.Views  5   	   C&clr-namespace:TradeUpHelper.ViewModelsTradeUpHelper.ViewModels  69   K*clr-namespace:TradeUpHelper.DataConvertersTradeUpHelper.DataConverters  6s   .    (TradeUpHelper.Views.FroatRangeCalcWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:TradeUpHelper.Views     5   	   =
viewmodels&clr-namespace:TradeUpHelper.ViewModels     69   A
converters*clr-namespace:TradeUpHelper.DataConverters     6s      FloatRangeWindowTitle  � Title#  �   5   	   $	��600��69   $	��700��6F    � 	Resources 5
       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $1 +/Resources/Styles/WindowControlButtons.xaml?�6%   �� 5      $, &/Resources/Styles/TextBoxesStyles.xaml?�6%   �� 5      $) #/Resources/Styles/LabelsStyles.xaml?�6%   �� 5      $* $/Resources/Styles/ButtonsStyles.xaml?�6%   �� 5      $, &/Resources/Styles/TextBoxesStyles.xaml?�6%   �� 5      $4 ./Resources/Styles/MarketCheckerListStyles.xaml?�6%   �� 5      $+ %/Resources/Styles/MainMenuStyles.xaml?�6%   %    5       � DataContext 5      5  /TradeUpHelper.ViewModels.FroatRangeCalcWindowVM  5   
   .��5      �   Color_WindowBackground#���  6    5   
   ?  9TradeUpHelper.DataConverters.ContractResultColorConverter  ColorConverter7  1TradeUpHelper.DataConverters.RarityColorConverter  RarityColorConverter1  +TradeUpHelper.DataConverters.ImageConverter  ImageConverter��%W   &	       &	      &	 &       5      66     5       6.     5!      6(   5#       � RowDefinitions 5$   
   �� 5%      $��40 �6   �� 5&      $	��200 �6   �� 5'      $��* �6   �� 5(      $��40 �6   �� 5)      $��40 �6   .+�5,   
   �� $��0��6   $��17(�6:   $��Center=�6H   $��Center=�6c   
���������6   �� *
ScinName+6�   �� 51   
   $��1��6   $��0,0,0,0q�6i   $��Stretch=�6z   $��Stretch=�6�   ��6   �� *ScinImageUrl+ �� 	Converter# [ 6�   �� 53   
   $��2��6   
�������$��1q�63   ._�54      �  55      �� 56      $��* �6$   �� 57      $��* �6$   �� 58      $��* �6$   �� 59      $��* �6$   �� 5:      $��* �6$   �� 5;      $��* �6$   �� 5<      $��* �6$   �� 5=      $��* �6$    � ColumnDefinitions 5?      �� 5@      $��* �6'   �� 5A      $��* �6'   .+�5C      �� $��0��6   $�� ��6%   $��17(�61   $��Center=�6?   $��Center=�6Z   
�������6w   �� 5D      $��1��6   $��0��6%    
 FRWear#���  65   $��0,0,15,0q�6Y   $��21(�6k   $	��Top=�6y   $��0,0,0,0q�6�   $��Right=�6�   
�������6�   �� 5E      $��1��6   $��1��6%     FRNeedFloat#���  65   $��0,0,15,0q�6^   $��21(�6p   $	��Top=�6~   $��0,0,0,0q�6�   $
��Left=�6�   
�������6�   �� 5F      $��2��6   $��0��6%     WearFactoryNew#���  65   $��17(�6`   $��Center=�6n   $��Right=�6�   $��0,0,15,0q�6�   
�������6�   �� 5G      $��2��6   $��1��6%    �� ContentStringFormat$ {0:F5}��6Q   $��17(�6p   $��Center=�6~   $
��Left=�6�   
���������65   �� *	FloatFN+6�   �� 5H      $��3��6   $��0��6%     WearMinimalWear#���  65   $��17(�6a   $��Center=�6o   $��Right=�6�   $��0,0,15,0q�6�   
�������6�   �� 5I      $��3��6   $��1��6%   $ {0:F5}��6Q   $��17(�6p   $��Center=�6~   $
��Left=�6�   
���������65   �� *	FloatMW+6�   �� 5J      $��4��6   $��0��6%    	 WearFieldTested#��� 	 65   $��17(�6a   $��Center=�6o   $��Right=�6�   $��0,0,15,0q�6�   
�������6�   �� 5K      $��4��6   $��1��6%   $ {0:F5}��6Q   $��17(�6p   $��Center=�6~   $
��Left=�6�   
���������65   �� *	FloatFT+6�   �� 5L      $��5��6   $��0��6%    
 WearWellWorn#��� 
 65   $��17(�6^   $��Center=�6l   $��Right=�6�   $��0,0,15,0q�6�   
�������6�   �� 5M      $��5��6   $��1��6%   $ {0:F5}��6Q   $��17(�6p   $��Center=�6~   $
��Left=�6�   
���������65   �� *	FloatWW+6�   �� 5N      $��6��6   $��0��6%     WearBattleScared#���  65   $��17(�6b   $��Center=�6p   $��Right=�6�   $��0,0,15,0q�6�   
�������6�   �� 5O      $��6��6   $��1��6%   $ {0:F5}��6Q   $��17(�6p   $��Center=�6~   $
��Left=�6�   
���������65   �� *	FloatBS+6�   5R      5S      �� 5V   
   $��3��6     ScinUrlForFloatRange#���  68   ��6   �� *	ScinUrl+68   �� 5W   
   $��4��6     SelectButton#���  6:   ��6   �� *	bSelect+6:   5Y      5Z      