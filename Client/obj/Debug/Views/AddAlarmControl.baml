   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Client.ViewsClient.Views  5      "    Client.Views.AddAlarmControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:Client.Views     5      .��5	      �   � RowDefinitions  5
   
   �� 5      $	��200 �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��60��6   $��0��6   $��1��6,   $
��Left=�6<   $��50q�6W   $��50��6c   ��6o   �� *PossibleHours+ �� Mode$ OneWay=� �� SelectedValue 6�   �� *SelectedHour+$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=� �� SelectedIndex 6�   �� *IndexH+$ TwoWay=�6+  �� 5   
   $��:��6   $��0��6   $��1��6)   $��Center=�69   $��38��6W   $��20(�6c   �� 5   
   $��60��6   $��50��6   $��0��6+   $��1��68   $��50q�6H   $��Right=�6T   ��6p   �� *PossibleMinutes+$ OneWay=� 6�   �� *SelectedMinute+$ TwoWay=�$ PropertyChanged=� 6   �� *IndexM+$ TwoWay=�60  �� 5   
   $��OK��6   $��1��6   $��0��6,   $	��150��6=   $��50q�6K   $��20��6W   ��6d   �� *AddAlarmCommand+6�   �� 5   
   $
��Back��6   $��1��6    $��1��6.   $	��150��6?   $��50q�6N   $��20��6[   ��6g   �� *BackCommand+6�   �� 5   
   $
��Exit��6   $��1��6    $��2��6.   $	��150��6?   $��50q�6M   $��20��6Z   ��6f   �� *ExitCommand+6�   5       5!      