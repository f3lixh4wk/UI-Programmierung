   M S B A M L   `   `   `  ����L  HGruppe01_Uebung10, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:PersonModelPersonModel  5   	   "    Gruppe01_Uebung10.MainWindow   5   	   W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:PersonModel     5   	     � Title$  
MainWindow��5   	    � WindowStartupLocation$ CenterScreen=�6   $	��450��6C   $	��800��6P    � 
ResizeMode$ NoResize=�6\    � 	Resources 5
         PersonModel.Personenliste   AllePersonen �� 
TargetType �� Property �� Value��%�   &	        '��        5   
   6   �� 5   
   " ��6   .�5      ��  � ��$ Verdana)�6+   �� 5       � ��$ 11(�6)   �� 5       � ��$ 10q�6(   5      5       � DataContext 5         PersonModel.MainViewModel  5   
   .��5      �  � RowDefinitions 5   
   �� 5      $	��225 �6   �� 5      $	��225 �6   	 � ColumnDefinitions	 5   
   �� 5      $	��400 �6   �� 5      $	��400 �6   .+�5   
   �� -   5        
 ��Name$
 	lb_person��5      $	��300��6%   $	��350��61   $��0��6>   $��0��6K   $��50,40,50,40q�5       $��2��6'   $ �� IsSynchronizedWithCurrentItem$
 TrueY�68   ��5!      �� *	Perslst+ �� SelectedItem 64   �� *SelectedPerson+��5"      �� 5#      .R�5$      �� $	��270��6!    �� Orientation$ 
Horizontal=�6-   .+�5%      �� $��85��6$   ��62   �� *	FirstName+�� 5&      $	��120��6$   ��63   �� *
LastName+�� 5'      ��6$   �� *	BirthDate+5(      5)      5+      �� 5-   
   $��	Vorname: ��6   $��0��6%   $��1��62   $��50,50,260,150q�6B   $��Right=�6Y   �� 5.   
   $��
Nachname: ��6   $��0��6&   $��1��63   $��50,100,260,100q�6C   $��Right=�6[   �� 5/   
   $��Geburtsdatum: ��6   $��0��6*   $��1��67   $��50,150,260,50q�6G   $��Right=�6^   �� 51   
   -   5         ��Name$ tb_personFirstName��51      $��0��6.   $��1��6;   $��20��6K   $	��150��6W   $��150,50,100,155q�6c   ��6{   �� *SelectedPerson.FirstName+�� 52   
   -   5        $ tb_personLastName��52      $��0��6-   $��1��6:   $��20��6J   $	��150��6V   $��150,100,100,105q�6b   ��6{   �� *SelectedPerson.LastName+�� 53   
   -   5        $ tb_personBirthDate��53      $��0��6.   $��1��6;   $��20��6K   $	��150��6W   $��150,150,100,55q�6c   ��6{   �� *SelectedPerson.BirthDate+�� 55   
   -   5         ��Name$ btn_sort��55      $��	Sortieren��6#   $��1��67   $��1��6G   $��20��6T   $��75��6`   $��25,50,275,155q�6k   6�   �� 56   
   -   5        $ btn_new��56      $	��Neu��6"   $��1��60   $��1��6@   $��20��6M   $��75��6Y   $��150,50,150,155q�6d   6|   �� 57   
   -   5        $ 
btn_delete��57      $��Löschen��6%   $��1��67   $��1��6G   $��20��6T   $��75��6`   $��275,50,25,155q�6k   6�   �� 58   
   -   5        $ 	btn_reset��58      $��Zurücksetzen��6$   $��1��6;   $��1��6K   $��20��6X   $��75��6d   6o   �� 5:   
   -	   5         ��Name$ tb_info��5:      $��1��6%   $��1��65   $	��300��6B   $��20��6N   $��50,140,50,70q�6Z   
����  � �� TextAlignment$ Center=�6�   5<      5=      