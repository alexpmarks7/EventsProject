   M S B A M L   `   `   `  ����K  GEventsProjectGUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:EventsProjectGUIEventsProjectGUI  5   	   %    EventsProjectGUI.NewEventWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:EventsProjectGUI     5   	     � Title$  NewEventWindow��5   	   $	��250��6    $	��750��6-    � WindowStartupLocation$ CenterScreen=�69   .��5	      � ��5
      �� 5       �� ImageSource$? 9C:\GitHub\Main_Project\Main Project Images\background.jpg��6    �� Opacity$	 0.1Q�6X   6h    � ColumnDefinitions 5      �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6    � RowDefinitions 5      �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5      �� -   5         ��Name$ FixtureGenre��5   
   $��0��6    $��0��60   $��18(�6=   6M   �� 5      -   5        $ 
SportMusic��5   
   $��0��6   $��1��6.   $��18(�6;   .��6I   Sport / Music6X   �� 5      -   5        $ TypeSM��5   
   $��0��6   $��2��6*   $��18(�67   6G   �� 5       -   5        $ Venue��5    
   $��0��6   $��5��6)   $��18(�66   .��6D   Venue6K   �� 5!      -   5        $
 Date��5!   
   $��2��6   $��1��6(   $��18(�65   .��6C   Date6I   �� 5"      -   5        $
 Time��5"   
   $��2��6   $��2��6(   $��18(�65   .��6C   Time6I   �� 5#      -   5        $ TicketsSold��5#   
   $��2��6   $��4��6/   $��18(�6<   .��6J   Tickets Sold6X   �� 5$      -   5        $ NewGenre��5$   
   $��0��6   $��4��6,   $��18(�69   6I   �� 5%      -	   5        $ 
NewGenreId��5%   
   $��0��6   $��3��6.   $��18(�6;   6K   �� 5'      -
   5         ��Name$ FixtureGenreInfo��5'      $��1��6&   $��0��66   $��3��6C    J� Opacity$
 0.55Q�6W   �� 5(      -   5        $ DateInfo��5(      $��3��6   $��1��6.   $
 0.55Q�6;   �� 5)      -   5        $ TimeInfo��5)      $��3��6   $��2��6.   $
 0.55Q�6;   �� 5*      -   5        $ TicketsSoldInfo��5*      $��3��6%   $��4��65   $
 0.55Q�6B   �� 5+      -   5        $ NewGenreInfo��5+      $��1��6"   $��4��62   $y�Hidden=�6?   �� 5,      -   5        $ NewGenreIdInfo��5,      $��1��6$   $��3��64   $y�Hidden=�6A   �� 5.      -   5        	 ��Name$	 NewVenue��5.      
 �� MaxDropDownHeight$
 90��6   $
��Auto=�66   $��1��6f   $��5��6v   6�   �� 5/      -   5        $	 SportMusicBox��5/      $
 90��6$   $
��Auto=�6;   $��1��6k   $��1��6{   6�   �� 50      -   5        $	 TypeBox��50      $
 90��6   $
��Auto=�65   $��1��6e   $��2��6u   $y�Hidden=�6�   6�   �� 51      -   5         ��Name$ AddEvent��51      $��3��6   $��5��6-   .��6Q   	Add Event6\   54      55      