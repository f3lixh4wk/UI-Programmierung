   M S B A M L   `   `   `  ����L  HGruppe01_Uebung10, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Gruppe01_Uebung10Gruppe01_Uebung10  5   	   .    (Gruppe01_Uebung10.winBenutzerHinzufügen   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:Gruppe01_Uebung10     5   	   -   5          �Name$  BenutzerHinzufügen��5   c    � Title$ Benutzer Hinzufügen��6	    � WindowStartupLocation$ CenterScreen=�6%   $	��250��6J   $	��400��6W   .��5
      � $��2q�6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��35 �6    � ColumnDefinitions 5   
   �� 5      $	��150 �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��1��6   $
��Left=�6/   $��Center=�6Q   ��6s   �� *PersonHinzufügenVorname+�� 5   
   $��1��6   $��1��6   $
��Left=�6/   $��Center=�6Q   ��6s   �� *PersonHinzufügenNachname+�� 5   
   $��2��6   $��1��6   $
��Left=�6/   $��Center=�6Q   ��6s   �� *PersonHinzufügenGeburtsdatum+�� 5   
   $��Vorname:��6   $��Center=�6#   $��Center=�6@   $��0��6[   $��0��6h   �� 5   
   $��	Nachname:��6   $��Center=�6$   $��Center=�6A   $��1��6\   $��0��6i   �� 5   
   $��Geburtsdatum:��6   $��Center=�6(   $��Center=�6E   $��2��6`   $��0��6m   �� 5   
    �� Orientation$ 
Horizontal=�6   $��3��6.   $��1��6;   .+�5      �� -   5        $��Anlegen��5      $��0,0,5,0q�6'   $��5q�68   $��75��6D   6O   �� 5      -   5        $��Abbruch��5      $��0,0,5,0q�6'   $��5q�68   $��75��6D   6O   5      5       5"      