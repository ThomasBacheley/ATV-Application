   M S B A M L   `   `   `  ����L  HApplication_Stage, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Application_StageApplication_Stage  5   	   "    Application_Stage.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:Application_Stage     5   	     � Title$  Application ATV��5   	   $	��580��6!   $
��1065��6.   $
��1065��6;   $	��580��6K   $��Center=�6[   $��Center=�6}    � SizeToContent$ WidthAndHeight=�6�   $	��580��6�   $
��1065��6�    � WindowStartupLocation$ CenterScreen=�6�    � WindowState$ 	Maximized=�6  ��.  � 
ResizeMode$ NoResize=�6.  .��5	      �� -   5         ��Name$ tabcontrolapp��5	      $
��Left=�6(   $	��520��6C   $��	10,10,0,0q�6P   $	��Top=�6c   $
��1030��6{    J� RenderTransformOrigin$ 0.5,0.5&�6�   .@�5
   
   �� -   5         ��Name$ 	TB_client��5
      $��Client��6%   $��-2,-2,-73,0q�65   .��5      � ���	#FFE5E5E5.+�5      �� $��Nom :��6   $
��Left=�6(   $��	10,30,0,0q�6C   $	��Top=�6V   �� 5      $��	Prénom :��6   $
��Left=�6+   $��
10,130,0,0q�6F   $	��Top=�6Z   �� 5      $��	Adresse :��6   $
��Left=�6,   $��
10,180,0,0q�6G   $	��Top=�6[   �� 5      -   5         ��Name$ txtbox_client_nom��5      $
��Left=�65   $��23��6P   $��
105,33,0,0q�6\   	 �� TextWrapping$
	 Wrap=�6p   $�� ��6�   $	��Top=�6�   $	��150��6�   
 �� MaxLines$
 1��6�    �� TextAlignment$ Center=�6�   $��1��6�   $��Center=�6�   6  �� 5      -   5        $ txtbox_client_prenom��5      $
��Left=�68   $��23��6S   $��105,130,0,0q�6_   $
	 Wrap=�6t   $�� ��6�   $	��Top=�6�   $	��150��6�   $
 1��6�   $ Center=�6�   $��2��6�   $��Center=�6�   �� 5      -   5        $ txtbox_client_adresse_rue��5      $
��Left=�6=   $��23��6X   $��105,210,0,0q�6d   $
	 Wrap=�6y   $�� ��6�   $	��Top=�6�   $	��150��6�    � ToolTip$ Entrer la Rue��6�    J� IsHitTestVisible . $
 1��6�   $ Center=�6�   $��3��6  $��Center=�6  �� 5      -   5        $! txtbox_client_adresse_ville��5      $
��Left=�6?   $��23��6Z   $��105,245,0,0q�6f   $
	 Wrap=�6{   $�� ��6�   $	��Top=�6�   $	��150��6�   $ Entrer la Ville��6�   $
 1��6�   $ Center=�6�   $��4��6�   $��Center=�6  �� 5      -   5        $&  txtbox_client_adresse_codepostal��5      $
��Left=�6D   $��23��6_   $��105,280,0,0q�6k   $
	 Wrap=�6�   $�� ��6�   $	��Top=�6�   $	��150��6�   $ Entrer le Code Postal��6�    �� 	MaxLength$ 5��6�   $
 1��6�   $ Center=�6�   $��5��6  $��Center=�6  �� 5      -   5        $ txtbox_client_tel_fix��5      $
��Left=�69   $��23��6T   $��105,380,0,0q�6`   $
	 Wrap=�6u   $�� ��6�   $	��Top=�6�   $	��150��6�   $ 10��6�   $
 1��6�   $ Center=�6�   $��6��6�   $��Center=�6�   �� 5      -	   5        $ txtbox_client_mail��5      $
��Left=�66   $��23��6Q   $��105,330,0,0q�6]   $
	 Wrap=�6r   $�� ��6�   $	��Top=�6�   $	��150��6�   $
 1��6�   $ Center=�6�   $��7��6�   $��Center=�6�   �� 5      $��Téléphone Fix :��6   $
��Left=�62   $��
10,380,0,0q�6M   $	��Top=�6a   �� 5      $��Mail :��6   $
��Left=�6)   $��
10,330,0,0q�6D   $	��Top=�6X   �� 5      -
   5         ��Name$ 	lb_client��5      $
��Left=�6-   $	��325��6H   $��
350,30,0,0q�6U   $	��Top=�6i   $	��645��6�   6�   �� 5      -   5         ��Name$ btn_client_ajouter��5      $��Ajouter��65   $
��Left=�6G   $��150,450,0,0q�6b   $	��Top=�6w   $��90��6�   $��8��6�   �� 5      -   5        $ btn_client_modif��5      $��Modifier��63   $
��Left=�6F   $��350,450,0,0q�6a   $	��Top=�6v   $	��100��6�   {�.  $��9��6�   �� 5      -   5        $ btn_client_supprimer��5      $��	Supprimer��67   $
��Left=�6K   $��765,450,0,0q�6f   $	��Top=�6{   $	��110��6�   {�.  $��11��6�   �� 5      -   5        $ btn_client_selection��5      $��Selectionner��67   $
��Left=�6N   $��535,450,0,0q�6i   $	��Top=�6~   $	��120��6�   $��10��6�   {�.  6�   �� 5      $��- Rue :��6   $
��Left=�6*   $��
15,210,0,0q�6E   $	��Top=�6Y   �� 5      $��	- Ville :��6   $
��Left=�6,   $��
15,245,0,0q�6G   $	��Top=�6[   �� 5      $��- Code postal :��6   $
��Left=�62   $��
15,280,0,0q�6M   $	��Top=�6a   	� 5       -   5         	�Name$ rb_client_entreprise��5       $��
Entreprise��6<   $
��Left=�6Q   $��	65,80,0,0q�6l   $	��Top=�6   6�   	� 5!      -   5        $ rb_client_particulier��5!      $��Particulier��6=   $
��Left=�6S   $��
190,80,0,0q�6n   $	��Top=�6�   6�   �� 5"      -   5        $  txtbox_client_tel_portable��5"      $
��Left=�6>   $��23��6Y   $��410,380,0,0q�6e   $
	 Wrap=�6z   $�� ��6�   $	��Top=�6�   $	��150��6�   $ 10��6�   $
 1��6�   $ Center=�6�   $��6��6�   $��Center=�6�   �� 5#      $��Téléphone Portable :��6   $
��Left=�67   $��285,380,0,0q�6R   $	��Top=�6g   5$      5%      �� 5&   
   -   5        $ TB_chantier��5&      $��Chantier��6'   $��73,-2,-148,0q�69   .��5'      � ���	#FFE5E5E5.+�5(      �� $��Nom Chantier :��6   $
��Left=�61   $��	71,75,0,0q�6L   $	��Top=�6_   �� 5)      -   5        $ txtbox_chantier_nom��5)      $
��Left=�67   $��23��6R   $��
210,75,0,0q�6^   $
	 Wrap=�6r   $	��Top=�6�   $	��175��6�   $��2��6�   $��Center=�6�   �� 5*      $��	Adresse :��6   $
��Left=�6,   $��
71,115,0,0q�6G   $	��Top=�6[   �� 5+      -   5        $ txtbox_chantier_rue��5+      $
��Left=�67   $��23��6R   $��210,140,0,0q�6^   $
	 Wrap=�6s   $	��Top=�6�   $	��175��6�   $��3��6�   $��Center=�6�   $ Entrer la Rue��6�   �� 5,      $��Client :��6   $
��Left=�6+   $��	71,35,0,0q�6F   $	��Top=�6Y   �� 5-      -   5        $ txtbox_chantier_client��5-      $
��Left=�6:   $��23��6U   $��
210,35,0,0q�6a   $
	 Wrap=�6u   $	��Top=�6�   $	��175��6�   $��1��6�   $��Center=�6�   $ Entrer le nom du Client��6�   6�   �� 5.      -   5        $ btn_chantier_valide��5.      $��Selectionner��66   $
��Left=�6M   $��550,425,0,0q�6h   $	��Top=�6}   $	��140��6�   $��6��6�   {�.  6�   �� 5/      -   5        $ btn_chantier_modif��5/      $��Modifier��65   $
��Left=�6H   $��335,425,0,0q�6c   $	��Top=�6x   $	��140��6�   $��7��6�   {�.  6�   �� 50      -   5        $ btn_chantier_ajouter��50      $��Ajouter��67   $
��Left=�6I   $��165,425,0,0q�6d   $	��Top=�6y   $	��140��6�   $��8��6�   6�   �� 51      -   5        $ btn_chantier_supprimer��51      $��	Supprimer��69   $
��Left=�6M   $��720,425,0,0q�6h   $	��Top=�6}   $	��140��6�   $��9��6�   {�.  6�   �� 52      -   5        $ txtbox_chantier_ville��52      $
��Left=�69   $��23��6T   $��210,175,0,0q�6`   $
	 Wrap=�6u   $	��Top=�6�   $	��175��6�   $��4��6�   $��Center=�6�   $ Entrer la Ville��6�   �� 53      -   5        $ txtbox_chantier_CP��53      $
��Left=�66   $��23��6Q   $��210,210,0,0q�6]   $
	 Wrap=�6r   $	��Top=�6�   $	��175��6�   $��5��6�   $��Center=�6�   $
 1��6�   $ 5��6�   $ Entrer le Code Postal��6�   �� 54      $��Date de réception :��6   $
��Left=�66   $��
70,340,0,0q�6Q   $	��Top=�6e   (  "System.Windows.Controls.DatePicker  55      -   5          Name$ dtp_chantier_reception��55      $
��Left=�6=   $��220,340,0,0q�6X   $	��Top=�6m   $	��175��6�      SelectedDateFormat$
 Long=�6�   �� 56      $��Date de marché :��6   $
��Left=�63   $��
70,265,0,0q�6N   $	��Top=�6b     57      -   5        $ dtp_chantier_marche��57      $
��Left=�6:   $��220,265,0,0q�6U   $	��Top=�6j   $	��175��6�   $
 Long=�6�   �� 58      -   5        $ lb_chantier��58      $
��Left=�6/   $	��340��6J   $��
505,25,0,0q�6W   $	��Top=�6k   $	��475��6�   6�   �� 59      $��	- Ville :��6   $
��Left=�6,   $��120,175,0,0q�6G   $	��Top=�6\   �� 5:      $��- Code Postal :��6   $
��Left=�62   $��120,210,0,0q�6M   $	��Top=�6b   �� 5;      $��- Rue :��6   $
��Left=�6*   $��120,140,0,0q�6E   $	��Top=�6Z   5<      5=      �� 5>   
   -   5        $ 
TB_produit��5>      $��Produit��6&   $��573,-2,-648,0q�67   .��5?      � ���	#FFE5E5E5.+�5@      � $
��Left=�6   $	��472��62   $��	10,10,0,0q�6?   $	��Top=�6R   $	��485��6j   ���	#FFDBD6D6.+�5A      �� $��Nom :��6   $
��Left=�6,   $��5,55,0,0q�6G   $	��Top=�6Y   �� 5B      $��Caractéristique :��6   $
��Left=�68   $��5,95,0,0q�6S   $	��Top=�6e   �� 5C      $��Type :��6   $
��Left=�6-   $��	5,135,0,0q�6H   $	��Top=�6[   �� 5D      $��
Système :��6   $
��Left=�60   $��	5,175,0,0q�6K   $	��Top=�6^   �� 5E      $��	Support :��6   $
��Left=�60   $��
15,255,0,0q�6K   $	��Top=�6_   �� 5F      $��Fournisseur :��6   $
��Left=�64   $��255,135,0,0q�6O   $	��Top=�6d   �� 5G      $��Fabricant :��6   $
��Left=�62   $��255,175,0,0q�6M   $	��Top=�6b   �� 5H      $��Consomation :��6   $
��Left=�64   $��
10,215,0,0q�6O   $	��Top=�6c   $��90��6{   �� 5I      $��Épaisseur :��6   $
��Left=�62   $��
255,95,0,0q�6M   $	��Top=�6a   �� 5J      $��Prix Unitaire :��6   $
��Left=�66   $��255,215,0,0q�6Q   $	��Top=�6f   �� 5K      -    5        $ txtbox_produit_nom��5K      $
��Left=�6:   $��23��6U   $��
100,55,0,0q�6a   $
	 Wrap=�6u   $	��Top=�6�   $	��145��6�   6�   �� 5L      -!   5         ��Name$  cb_produit_caracteristique��5L      $
��Left=�6C   $��
100,95,0,0q�6^   $	��Top=�6r   $	��145��6�   �� 5M      -"   5        $ txtbox_produit_type��5M      $
��Left=�6;   $��23��6V   $��100,135,0,0q�6b   $
	 Wrap=�6w   $	��Top=�6�   $	��145��6�   �� 5N      -#   5        $ txtbox_produit_systeme��5N      $
��Left=�6>   $��23��6Y   $��100,175,0,0q�6e   $
	 Wrap=�6z   $	��Top=�6�   $	��145��6�   �� 5O      -$   5        $ txtbox_produit_support��5O      $
��Left=�6>   $��23��6Y   $��100,255,0,0q�6e   $
	 Wrap=�6z   $	��Top=�6�   $	��145��6�   �� 5P      -%   5        $  txtbox_produit_fournisseur��5P      $
��Left=�6B   $��23��6]   $��345,135,0,0q�6i   $
	 Wrap=�6~   $	��Top=�6�   $	��130��6�   �� 5Q      -&   5        $ txtbox_produit_fabricant��5Q      $
��Left=�6@   $��23��6[   $��345,175,0,0q�6g   $
	 Wrap=�6|   $	��Top=�6�   $	��130��6�   �� 5R      -'   5        $  txtbox_produit_consomation��5R      $
��Left=�6B   $��23��6]   $��100,215,0,0q�6i   $
	 Wrap=�6~   $	��Top=�6�   $	��145��6�   �� 5S      -(   5        $ txtbox_produit_prix��5S      $
��Left=�6;   $��23��6V   $��345,215,0,0q�6b   $
	 Wrap=�6w   $	��Top=�6�   $	��130��6�   $ 5��6�   �� 5T      -)   5        $ cb_produit_epaisseur��5T      $
��Left=�6=   $��
345,95,0,0q�6X   $	��Top=�6l   $	��130��6�   �� 5U      $��Grain :��6   $
��Left=�6.   $��
255,55,0,0q�6I   $	��Top=�6]   �� 5V      -*   5        $ cb_produit_grain��5V      $
��Left=�69   $��
345,55,0,0q�6T   $	��Top=�6h   $	��130��6�   �� 5W      -+   5        $ btn_produit_ajouter��5W      $��Ajouter��6:   $
��Left=�6L   $��
40,435,0,0q�6g   $	��Top=�6{   $��90��6�   6�   �� 5X      -,   5        $ btn_produit_modifier��5X      $��Modifier��6;   $
��Left=�6N   $��175,435,0,0q�6i   $	��Top=�6~   $��90��6�   6�   �� 5Y      --   5        $ btn_produit_supprimer��5Y      $��	Supprimer��6<   $
��Left=�6P   $��310,435,0,0q�6k   $	��Top=�6�   $��90��6�   6�   �� 5Z      $��Format :��6   $
��Left=�6/   $��255,255,0,0q�6J   $	��Top=�6_   �� 5[      -.   5        $ txtbox_produit_format��5[      $
��Left=�6=   $��23��6X   $��345,255,0,0q�6d   $
	 Wrap=�6y   $	��Top=�6�   $	��130��6�   �� 5\      $��	Produit :��6   $
��Left=�60   $��5,10,0,0q�6K   $	��Top=�6]   $��20(�6u   �� 5]      -/   5        $ LB_produit_produit��5]      $
��Left=�6:   $	��130��6U   $��
10,290,0,0q�6b   $	��Top=�6v   $	��465��6�   6�   5^      � 5_      ���	#FFDBD6D6$
��Left=�6.   $	��472��6I   $��
510,10,0,0q�6V   $	��Top=�6j   $	��505��6�   .+�5`      �� $��Réf :��6   $
��Left=�6,   $��
200,70,0,0q�6G   $	��Top=�6[   �� 5a      -0   5        $ txtbox_produit_ref��5a      $
��Left=�6:   $��23��6U   $��
235,70,0,0q�6a   $
	 Wrap=�6u   $	��Top=�6�   $��70��6�    �� 
IsReadOnly .  $ 3��6�   $��2��6�   $��Center=�6�   �� 5b      $��	Couleur :��6   $
��Left=�60   $��	10,70,0,0q�6K   $	��Top=�6^   �� 5c      -1   5        $ LB_produit_nuancier��5c      $
��Left=�6;   $	��270��6V   $��
15,103,0,0q�6c   $	��Top=�6w   $	��480��6�   6�   �� 5d      -2   5        $ txtbox_produit_couleur��5d      $
��Left=�6>   $��23��6Y   $��	70,70,0,0q�6e   $
	 Wrap=�6x   $	��Top=�6�   $	��125��6�   $��1��6�   �� 5e      $��Coefficient :��6   $
��Left=�64   $��209,392,0,0q�6O   $	��Top=�6d   �� 5f      $��Gamme :��6   $
��Left=�6.   $��
10,390,0,0q�6I   $	��Top=�6]   �� 5g      -3   5        $ txtbox_produit_gamme��5g      $
��Left=�6<   $��23��6W   $��
83,390,0,0q�6c    .  $
	 Wrap=�6�   $	��Top=�6�   $	��120��6�   $��3��6�   �� 5h      -4   5        $  btn_produit_ajouter_nuance��5h      $��Ajouter��6A   $
��Left=�6S   $��
60,435,0,0q�6n   $	��Top=�6�   $	��110��6�   $��7��6�   6�   �� 5i      -5   5        $  btn_produit_modif_nuancier��5i      $��Modifier��6A   $
��Left=�6T   $��190,435,0,0q�6o   $	��Top=�6�   $	��110��6�   $��8��6�   6�   �� 5j      -6   5        $  btn_produit_suppr_nuancier��5j      $��	Supprimer��6A   $
��Left=�6U   $��315,435,0,0q�6p   $	��Top=�6�   $	��110��6�   $��9��6�   6�   	� 5k      -7   5        $ rb_produit_coef1��5k   "   $
��<0,7��6<   $
��Left=�6N   $��286,398,0,0q�6i   $	��Top=�6~   $��4��6�   	� 5l      -8   5        $ rb_produit_coef2��5l   "   $��>=0,7��6<   $
��Left=�6O   $��338,398,0,0q�6j   $	��Top=�6   $��5��6�   	� 5m      -9   5        $ rb_produit_coef3��5m   "   $
��>0,7��6<   $
��Left=�6N   $��405,398,0,0q�6i   $	��Top=�6~   $��6��6�   �� 5n      $��Nuance :��6   $
��Left=�6/   $��	10,10,0,0q�6J   $	��Top=�6]   $��20(�6u   �� 5o      $��Plus-value :��6   $
��Left=�63   $��
315,70,0,0q�6N   $	��Top=�6b   �� 5p      -:   5        $ txtbox_produit_plus_value��5p      $
��Left=�6A   $��23��6\   $��
390,70,0,0q�6h   $
	 Wrap=�6|   $	��Top=�6�   $��80��6�    .  $ 3��6�   $��2��6�   $��Center=�6�   5q      5r      5s      �� 5t   
   -;   5        $ TB_fournisseur��5t      $��Fournisseur de matériaux��6*   $��73,-2,-78,0q�6L   .��5u      � ���	#FFE5E5E5.+�5v      �� $��Nom :��6   $
��Left=�6(   $��	80,25,0,0q�6C   $	��Top=�6V   �� 5w      $��	Adresse :��6   $
��Left=�6,   $��
430,25,0,0q�6G   $	��Top=�6[   �� 5x      $��Téléphone :��6   $
��Left=�6.   $��
80,125,0,0q�6I   $	��Top=�6]   �� 5y      $��Mail :��6   $
��Left=�6)   $��	80,80,0,0q�6D   $	��Top=�6W   �� 5z      -<   5        $ btn_fournisseur_ajoute��5z      $��Ajouter��69   $
��Left=�6K   $��
800,55,0,0q�6f   $	��Top=�6z   $	��100��6�   $��8��6�   6�   �� 5{      -=   5        $ btn_fournisseur_modif��5{      $��Modifier��68   $
��Left=�6K   $��800,110,0,0q�6f   $	��Top=�6{   $	��100��6�   {�.  $��9��6�   6�   �� 5|      ->   5        $! btn_fournisseur_selectionne��5|      $��Sélectionner��6>   $
��Left=�6U   $��800,165,0,0q�6p   $	��Top=�6�   $	��100��6�   $��10��6�   {�.  6�   �� 5}      -?   5        $ lb_fournisseur��5}      $
��Left=�62   $	��240��6M   $��
25,225,0,0q�6Z   $	��Top=�6n   $	��975��6�   6�   �� 5~      -@   5        $ txtbox_fournisseur_nom��5~      $
��Left=�6:   $��23��6U   $��
165,25,0,0q�6a   $
	 Wrap=�6u   $	��Top=�6�   $	��200��6�   $
 1��6�   $ Center=�6�   $��1��6�   $��Center=�6�   6  �� 5      -A   5        $ txtbox_fournisseur_rue��5      $
��Left=�6:   $��23��6U   $��
525,50,0,0q�6a   $
	 Wrap=�6u   $	��Top=�6�   $	��200��6�   $
 1��6�   $ Saissir la Rue��6�   $ Center=�6�   $��4��6�   $��Center=�6�   �� 5�      -B   5        $ txtbox_fournisseur_mail��5�      $
��Left=�6;   $��23��6V   $��
165,75,0,0q�6b   $
	 Wrap=�6v   $	��Top=�6�   $	��200��6�   $
 1��6�   $ Center=�6�   $��2��6�   $��Center=�6�   �� 5�      -C   5        $ txtbox_fournisseur_tel��5�      $
��Left=�6:   $��23��6U   $��165,125,0,0q�6a   $
	 Wrap=�6v   $	��Top=�6�   $	��200��6�   $
 1��6�   $ 10��6�   $ Center=�6�   $��3��6�   $��Center=�6�   �� 5�      -D   5        $ txtbox_fournisseur_ville��5�      $
��Left=�6<   $��23��6W   $��
525,88,0,0q�6c   $
	 Wrap=�6w   $	��Top=�6�   $	��200��6�   $
 1��6�   $ Saissir la Ville��6�   $ Center=�6�   $��6��6�   $��Center=�6�   �� 5�      -E   5        $ txtbox_fournisseur_CP��5�      $
��Left=�69   $��23��6T   $��525,126,0,0q�6`   $
	 Wrap=�6u   $	��Top=�6�   $	��200��6�   $
 1��6�   $ Saissir le Code Postal��6�   $ Center=�6�   $��7��6�   $��Center=�6   �� 5�      $��
Site Web :��6   $
��Left=�6-   $��430,170,0,0q�6H   $	��Top=�6]   �� 5�      -F   5        $ txtbox_fournisseur_site��5�      $
��Left=�6;   $��23��6V   $��525,175,0,0q�6b   $
	 Wrap=�6w   $	��Top=�6�   $	��200��6�   �� 5�      $��- Rue :��6   $
��Left=�6*   $��
440,50,0,0q�6E   $	��Top=�6Y   �� 5�      $��	- Ville :��6   $
��Left=�6,   $��
440,88,0,0q�6G   $	��Top=�6[   �� 5�      $��- Code Postal :��6   $
��Left=�62   $��440,126,0,0q�6M   $	��Top=�6b   5�      5�      �� 5�   
   -G   5        $ TB_commande��5�      $��Commande��6'   $��78,-2,-153,0q�69   .��5�      � ���	#FFE5E5E5.+�5�      �� -H   5        $ btn_commande_enregistrer��5�      $��Finaliser la Commande��6;   $
��Left=�6[   $��575,460,0,0q�6v   $	��Top=�6�   $	��145��6�   6�   �� 5�      -I   5        $ btn_commande_supprimer��5�      $��Supprimer la Commande��69   $
��Left=�6Y   $��810,460,0,0q�6t   $	��Top=�6�   $	��145��6�   � 5�      $
��Left=�6   $	��118��62   $	��Top=�6?   $	��475��6W   ���	#FFDBD6D6$��10,8,0,0q�6z   .+�5�      �� -J   5        $ txtbox_commande_num_cmd��5�      $
��Left=�6?   $��23��6Z   $��	170,8,0,0q�6f   $
	 Wrap=�6y   $	��Top=�6�   $��70��6�   6�   �� 5�      $��Numéro de Commande :��6   $
��Left=�6;   $��15,8,0,0q�6V   $	��Top=�6h   �� 5�      -K   5        $ lb_commande_commande��5�      $
��Left=�6<   $��70��6W   $��	10,38,0,0q�6c   $	��Top=�6v   $	��450��6�   5�      � 5�      $
��Left=�6   $	��208��62   $��
10,131,0,0q�6?   $	��Top=�6S   $	��475��6k   ���	#FFDBD6D6.+�5�      �� -L   5        $ lb_commande_produit��5�      $
��Left=�6;   $	��158��6V   $��	10,40,0,0q�6c   $	��Top=�6v   $	��450��6�   6�   �� 5�      -M   5        $ txtbox_commande_produit��5�      $
��Left=�6?   $��23��6Z   $��	235,9,0,0q�6f   $
	 Wrap=�6y   $	��Top=�6�   $	��135��6�   6�   �� 5�      $*��$Rechercher produit (par fabricant) :��6   $
��Left=�6K   $��
15,9,-32,0q�6f   $	��Top=�6z   5�      � 5�      $
��Left=�6   $	��141��62   $	��Top=�6?   $	��475��6W   ���	#FFDBD6D6$��
10,344,0,0q�6z   .+�5�      �� -N   5        $ txtbox_commande_teinte��5�      $
��Left=�6>   $��23��6Y   $��95,8,0,0q�6e   $
	 Wrap=�6w   $	��Top=�6�   $	��160��6�   6�   �� 5�      $��Teinte :��6   $
��Left=�6/   $��15,8,0,0q�6J   $	��Top=�6\   �� 5�      -O   5        $ lb_commande_nuance��5�      $
��Left=�6:   $��93��6U   $��	10,38,0,0q�6a   $	��Top=�6t   $	��455��6�   5�      � 5�      $
��Left=�6   $	��145��62   $��
490,10,0,0q�6?   $	��Top=�6S   $	��524��6k   ���	#FFDBD6D6.+�5�      �� $��Finaliser le Produit :��6   $
��Left=�6=   $��	10,10,0,0q�6X   $	��Top=�6k   �� 5�      $��Quantité :��6   $
��Left=�61   $��	60,40,0,0q�6L   $	��Top=�6_   �� 5�      -P   5        $ txtbox_commande_quantite��5�      $
��Left=�6@   $��23��6[   $��
127,40,0,0q�6g   $
	 Wrap=�6{   $	��Top=�6�   $��80��6�   $ 3��6�   $
 1��6�   6�   �� 5�      $��Prix unitaire (HT) :��6   $
��Left=�6;   $��	18,75,0,0q�6V   $	��Top=�6i   �� 5�      -Q   5        $# txtbox_commande_prix_unitaire��5�      $
��Left=�6E   $��23��6`   $��
127,75,0,0q�6l   $
	 Wrap=�6�   $	��Top=�6�   $��80��6�   $ 3��6�   $
 1��6�    . 6�   �� 5�      $	��€��6   $
��Left=�6(   $��
212,75,0,0q�6C   $	��Top=�6W   �� 5�      $��Prix Total (HT) :��6   $
��Left=�68   $��
271,75,0,0q�6S   $	��Top=�6g   �� 5�      -R   5        $  txtbox_commande_prix_total��5�      $
��Left=�6B   $��23��6]   $��
380,75,0,0q�6i   $
	 Wrap=�6}   $	��Top=�6�   $��80��6�   $ 3��6�   $
 1��6�    . 6�   �� 5�      $	��€��6   $
��Left=�6(   $��
465,75,0,0q�6C   $	��Top=�6W   �� 5�      -S   5        $ btn_commande_ajouter_prod��5�      $��Ajouter à la commande��6@   $
��Left=�6`   $��200,114,0,0q�6{   $	��Top=�6�   $	��145��6�   6�   �� 5�      -T   5         ��Name$ label_unite��5�      $
��Left=�61   $��
212,40,0,0q�6L   $	��Top=�6`   5�      � 5�      $
��Left=�6   $	��290��62   $��490,160,0,0q�6?   $	��Top=�6T   $	��524��6l   ���	#FFDBD6D6.+�5�      �� $$��Date de livraison souhaitée :��6   $
��Left=�6D   $��
70,245,0,0q�6_   $	��Top=�6s   $	��160��6�     5�      -U   5        $ dtp_livraison��5�   !   $
��Left=�68   $��240,245,0,0q�6S   $	��Top=�6h   $	��225��6�   6�   �� 5�      $��
Commande :��6   $
��Left=�61   $��	10,15,0,0q�6L   $	��Top=�6_   �� 5�      $��Client :��6   $
��Left=�6/   $��	10,50,0,0q�6J   $	��Top=�6]   �� 5�      $��
Chantier :��6   $
��Left=�61   $��	10,85,0,0q�6L   $	��Top=�6_   �� 5�      $��	Adresse :��6   $
��Left=�60   $��
10,120,0,0q�6K   $	��Top=�6_   �� 5�      $��Fournisseur :��6   $
��Left=�64   $��
10,215,0,0q�6O   $	��Top=�6c   �� 5�      -V   5        $ txtbox_commande_client��5�      $
��Left=�6>   $��23��6Y   $��	95,50,0,0q�6e   $
	 Wrap=�6x   $	��Top=�6�   $	��135��6�    . 6�   �� 5�      -W   5        $ txtbox_commande_chantier��5�      $
��Left=�6@   $��23��6[   $��	95,85,0,0q�6g   $
	 Wrap=�6z   $	��Top=�6�   $	��135��6�    . 6�   �� 5�      -X   5        $" txtbox_commande_chantier_rue��5�      $
��Left=�6D   $��23��6_   $��
95,145,0,0q�6k   $
	 Wrap=�6   $	��Top=�6�   $	��135��6�    . 6�   �� 5�      -Y   5        $$ txtbox_commande_chantier_ville��5�      $
��Left=�6F   $��23��6a   $��
95,180,0,0q�6m   $
	 Wrap=�6�   $	��Top=�6�   $	��135��6�    . 6�   �� 5�      -Z   5        $! txtbox_commande_fournisseur��5�      $
��Left=�6C   $��23��6^   $��
95,215,0,0q�6j   $
	 Wrap=�6~   $	��Top=�6�   $	��135��6�    . 6�   �� 5�      -[   5        $ lb_commande_produit_final��5�      $
��Left=�6A   $	��185��6\   $��
244,15,0,0q�6i   $	��Top=�6}   $	��270��6�   �� 5�      $��Total :��6   $
��Left=�6.   $��355,200,0,0q�6I   $	��Top=�6^   �� 5�      -\   5        $( "txtbox_commande_prix_total_produit��5�      $
��Left=�6J   $��23��6e   $��424,199,0,0q�6q   $
	 Wrap=�6�   $	��Top=�6�   $��90��6�    . 6�   �� 5�      $��- Rue :��6   $
��Left=�6.   $��
25,145,0,0q�6I   $	��Top=�6]   �� 5�      $��	- Ville :��6   $
��Left=�60   $��
25,180,0,0q�6K   $	��Top=�6_   5�      5�      5�      �� 5�   
   -]   5        $ 
TB_setting��5�      $��	Parametre��6&   $��428,-2,-503,0q�69   .��5�      � ���	#FFE5E5E5.+�5�      �� $
��Left=�6   $	��100��65   $��
10,262,0,0q�6B   $	��Top=�6V   $	��904��6n   �� 5�      $��Utilisateur��6   $
��Left=�6.   $��136,129,0,0q�6I   $	��Top=�6^   � 5�      ���	#FFE5E5E5.+�5�      �� $��Utilisateur :��6   $
��Left=�64   $��150,135,0,0q�6O   $	��Top=�6d   $ 0.531,1.692&�6|   �� 5�      $��Mot de passe :��6   $
��Left=�65   $��150,195,0,0q�6P   $	��Top=�6e   $ 0.531,1.692&�6}   �� 5�      $��Base de données :��6   $
��Left=�68   $��150,250,0,0q�6S   $	��Top=�6h   $ 0.531,1.692&�6�   �� 5�      -^   5        $ 
txtbox_bdd��5�      $
��Left=�62   $��23��6M   $��275,250,0,0q�6Y   $
	 Wrap=�6n   $�� ��6�   $	��Top=�6�   $	��120��6�   $
 1��6�   $ Center=�6�   $��3��6�   $��Center=�6�   �� 5�      -_   5        $ txtbox_user��5�      $
��Left=�63   $��23��6N   $��275,135,0,0q�6Z   $
	 Wrap=�6o   $�� ��6�   $	��Top=�6�   $	��120��6�   $
 1��6�   $ Center=�6�   $��1��6�   $��Center=�6�   �� 5�      $��	Serveur :��6   $
��Left=�60   $��580,135,0,0q�6K   $	��Top=�6`   $ 0.531,1.692&�6x   �� 5�      $��Port :��6   $
��Left=�6-   $��581,195,0,0q�6H   $	��Top=�6]   $ 0.531,1.692&�6u   �� 5�      -`   5        $ txtbox_port��5�      $
��Left=�63   $��23��6N   $��710,195,0,0q�6Z   $
	 Wrap=�6o   $�� ��6�   $	��Top=�6�   $	��120��6�   $
 1��6�   $ Center=�6�   $��5��6�   $��Center=�6�   $ 7��6   . 6  �� 5�      -a   5        $ txtbox_server��5�      $
��Left=�65   $��23��6P   $��710,135,0,0q�6\   $
	 Wrap=�6q   $�� ��6�   $	��Top=�6�   $	��120��6�   $
 1��6�   $ Center=�6�   $��4��6�   $��Center=�6�   �� 5�      -b   5        $ btn_modif_setting��5�      $��Valider les changements��68   $
��Left=�6Z   $��685,253,0,0q�6u   $	��Top=�6�   $	��145��6�   $��6��6�   G� 5�      -c   5         G�Name$ 
pswbox_psw��5�   "   $
��Left=�66   $��Center=�6Q   $��23��6u   $��275,195,0,0q�6�   $	��Top=�6�   $	��120��6�   $��2��6�   $��Center=�6�   �� 5�      $��Chemin d'acces Fichier :��6   $
��Left=�6?   $��150,330,0,0q�6Z   $	��Top=�6o   �� 5�      -d   5        $ txtbox_chemin��5�      $
��Left=�65   $��23��6P   $��337,330,0,0q�6\   $
	 Wrap=�6q   $	��Top=�6�   $	��280��6�   �� 5�      -e   5        $ 
btn_chemin��5�      $��Modifier Chemin��61   $
��Left=�6K   $��685,330,0,0q�6f   $	��Top=�6{   $	��145��6�   $��6��6�   6�   5�      5�      5�      5�      5�      