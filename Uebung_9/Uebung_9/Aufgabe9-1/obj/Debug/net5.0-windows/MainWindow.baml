   M S B A M L   `   `   `  ����E  AAufgabe9-1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Aufgabe9_1
Aufgabe9_1  5   	       Aufgabe9_1.MainWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:Aufgabe9_1     5   	     � Title$  Uebung9_Aufgabe9-1��5   	   $	��220��6$   $	��520��61    � 	Resources 5	         ButtonTemplate1 �� 
TargetType A�Name �� 
StartPoint �� EndPoint � Offset � Color �� Triggers	 P� Property
 P� Value �� 
TargetName �� Property �� Value �� ScaleX �� ScaleY �� 
TargetType �� Triggers :� RoutedEvent g� Duration �� TargetProperty	 W� To��%?  &	        '�� �    �� 5
      " ��6,   .R�5      � .+�5      A� $ ButtonEllipse1��6   $	��120��6&   $	��500��63   ��5      �� 5      $	 0,0&�6   $	 4,0&�6-   .��5   	   � $ 0Q�6   $
 Cyan��6!   � 5   	   $ 1Q�6   $ Orange��6!   5   	   5      A� 5      $ ButtonEllipse2��6   $	��120��6&   $	��120��63   ��5      �� 5      $ 0.5,0.6&�6   $	 0,0&�61   .��5   	   � $ 0Q�6   $
 Blue��6"   � 5   	   $ 1Q�6   $ White��6"   5   	   5      �� 5      #��z��6   $��Center=�6;   $��Center=�6X   5       5      P� 5      	 �@J�IsMouseOver$

 True��6%   . �5       �� $ ButtonEllipse1��6    � ��
 �  ��6:   5!      P� 5"      	 � ��$

 True��6#   . �5#      ��  � z� 5$      �� 5%   	   $	 0.9Q�6   $	 0.9Q�6%   5'      �� 5(       �@J�RenderTransformOrigin$ 0.5,0.5&�6/   5)      5+      �� 5,      " ��6
    5-      :� 5.      $ 
MouseEnter��6   [�5/      �� 50      .��51   	   �� .��52   
   W� $ 0D�6   $ FontSize�6'    366L   53   
   54   	   56      :� 57      $ 
MouseLeave��6   [�58      �� 59      .��5:   	   �� .��5;   
   W� $ 0D�6   $ FontSize�6'    206L   5<   
   5=   	   5?      5A      5B      .��5C      �� .+�5D      �� $��Button Template��6   
�������#��[  68   �� 5E      $��Standard Button��6   $��50��6%   �� 5F      $
��Test��6   $	�� 20��6   6)   5G      5H      