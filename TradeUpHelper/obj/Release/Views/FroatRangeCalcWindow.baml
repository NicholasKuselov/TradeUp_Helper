   M S B A M L   `   `   `  ���� H  DTradeUpHelper, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:TradeUpHelper.ViewsTradeUpHelper.Views  C&clr-namespace:TradeUpHelper.ViewModelsTradeUpHelper.ViewModels  K*clr-namespace:TradeUpHelper.DataConvertersTradeUpHelper.DataConverters  .    (TradeUpHelper.Views.FroatRangeCalcWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     3local!clr-namespace:TradeUpHelper.Views     =
viewmodels&clr-namespace:TradeUpHelper.ViewModels     A
converters*clr-namespace:TradeUpHelper.DataConverters        FloatRangeWindowTitle  � Title#  �   $	��600��$	��700�� � 	Resources  �� MergedDictionaries �� Source��  �� $1 +/Resources/Styles/WindowControlButtons.xaml?��� $, &/Resources/Styles/TextBoxesStyles.xaml?��� $) #/Resources/Styles/LabelsStyles.xaml?��� $* $/Resources/Styles/ButtonsStyles.xaml?��� $, &/Resources/Styles/TextBoxesStyles.xaml?��� $4 ./Resources/Styles/MarketCheckerListStyles.xaml?��� $+ %/Resources/Styles/MainMenuStyles.xaml?�%     � DataContext 5  /TradeUpHelper.ViewModels.FroatRangeCalcWindowVM  .���   Color_WindowBackground#���   ?  9TradeUpHelper.DataConverters.ContractResultColorConverter  ColorConverter7  1TradeUpHelper.DataConverters.RarityColorConverter  RarityColorConverter1  +TradeUpHelper.DataConverters.ImageConverter  ImageConverter��%-   &	       &	      &	 
            � RowDefinitions �� $��40 ��� $	��200 ��� $��* ��� $��40 ��� $��40 �.+��� $��0��$��17(�$��Center=�$��Center=�
����������� *
ScinName+�� $��1��$��0,0,0,0q�$��Stretch=�$��Stretch=����� *ScinImageUrl+ �� 	Converter# [ �� $��2��
�������$��1q�._��  �� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* � � ColumnDefinitions �� $��* ��� $��* �.+��� $��0��$�� ��$��17(�$��Center=�$��Center=�
��������� $��1��$��0�� 
 FRWear#���  $��0,0,15,0q�$��21(�$	��Top=�$��0,0,0,0q�$��Right=�
��������� $��1��$��1��  FRNeedFloat#���  $��0,0,15,0q�$��21(�$	��Top=�$��0,0,0,0q�$
��Left=�
��������� $��2��$��0��  WearFactoryNew#���  $��17(�$��Center=�$��Right=�$��0,0,15,0q�
��������� $��2��$��1�� �� ContentStringFormat$ {0:F5}��$��17(�$��Center=�$
��Left=�
����������� *	FloatFN+�� $��3��$��0��  WearMinimalWear#���  $��17(�$��Center=�$��Right=�$��0,0,15,0q�
��������� $��3��$��1��$ {0:F5}��$��17(�$��Center=�$
��Left=�
����������� *	FloatMW+�� $��4��$��0�� 	 WearFieldTested#��� 	 $��17(�$��Center=�$��Right=�$��0,0,15,0q�
��������� $��4��$��1��$ {0:F5}��$��17(�$��Center=�$
��Left=�
����������� *	FloatFT+�� $��5��$��0�� 
 WearWellWorn#��� 
 $��17(�$��Center=�$��Right=�$��0,0,15,0q�
��������� $��5��$��1��$ {0:F5}��$��17(�$��Center=�$
��Left=�
����������� *	FloatWW+�� $��6��$��0��  WearBattleScared#���  $��17(�$��Center=�$��Right=�$��0,0,15,0q�
��������� $��6��$��1��$ {0:F5}��$��17(�$��Center=�$
��Left=�
����������� *	FloatBS+�� $��3��  ScinUrlForFloatRange#���  ���� *	ScinUrl+�� $��4��  SelectButton#���  ���� *	bSelect+