   M S B A M L   `   `   `  ����D  @TestMaker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:FirstApp.ViewsFirstApp.Views  5          FirstApp.Views.TestView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:FirstApp.Views     5      ^ ZCaliburn.Micro.Platform, Version=3.2.0.0, Culture=neutral, PublicKeyToken=8e5891231f2ed21f(calhttp://www.caliburnproject.org  5      
�������$��Microsoft YaHei)�5	   J   .��5
      �� .��5   
   �   � ColumnDefinitions  5      �� 5      $	��150 �6#   �� 5      $��* �6#   �� 5      $��* �6#   �� 5      $��* �6#   �� 5      $��30 �6#   �� 5      $��* �6#    � RowDefinitions 5      �� 5      $��20 �6    �� 5      $
��auto �6    �� 5      $��20 �6    �� 5      $
��auto �6    �� 5      $��20 �6    �� 5      $
��auto �6    �� 5      $��20 �6    �� 5      $
��auto �6    �� 5      $��20 �6    �� 5"      $��* �6    �� 5#      $��20 �6    �� 5$      $��20 �6    .+�5+      �� $��1��6   $��1��6%   $��3��65   $
��Wrap=�6I   $��40(�6]    �� TextAlignment$ Center=�6k   ��6�   ��  �� Path$ CurrentQuestionText� �� Mode$ OneWay=��� 5.      $��3��6   $��1��6!   $��3��61   ��6E   �� $ CurrentImage�$ OneWay=�6y   �� 51      $��5��6M   $��1��6Z   $��3��6j   ��6   �� $ Answers�$ OneWay=���52      �� 53      .R�54      ��  �� Orientation$ Vertical=�6%   .+�55      �� ��6(   �� *
AnswerText+6F   56      57      59      �� 5=      -   5         ��Name$ Previous��5=      $��7��6'   $��1��64   $	��0,5q�6D   $	��100��6Q   $��Previous��6]   �� 5>      -   5        $
 Next��5>      $��7��6#   $��3��60   $	��0,5q�6@   $	��100��6M   $
��Next��6Y   �� 5?      -   5         ��Name$ Options��5?      $��7��6(   $��2��65   $	��0,5q�6E   $	��500��6R   $��25��6a    �� SelectedItem 5@      �� $ Chosen�$ TwoWay=�5A      �� 5E      $��1��6   $��6��6%   $ Center=�6]   	 �� Padding$
	 0,10q�6t   $��25(�6�   ��65   �� $
 Time�$ OneWay=�6�   �� 5F      $��3��6   $��6��6(   $��7��68   .��5H      �� -   5        
 ��Name$
 	Questions��5H      ��5I      �� 5J      .R�5K      A�  A� Columns$ 3��6*   5L      ��5N      �� 5O      .R�5P      �� $ Vertical=�6)   .+�5Q   "   ��   Caliburn.Micro.Message   Attach$3 -[Event Click] = [Action ItemClick($this.Tag)]��5R   )   
�������
���������5Q   )   �� *Number+
 � Tag 6D   �� *Number+5S   R   5T      5U      5W      5Y      �� 5[      -   5        $ Finished��5[      $��10��6'   $��5��65   $��80��6E   $��Finish Test��6P   6h   5\      5]      5^      