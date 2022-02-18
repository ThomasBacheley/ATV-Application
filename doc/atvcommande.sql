-- phpMyAdmin SQL Dump
-- version 4.5.4.1
-- http://www.phpmyadmin.net
--
-- Client :  localhost
-- Généré le :  Dim 08 Juillet 2018 à 22:00
-- Version du serveur :  5.7.11
-- Version de PHP :  5.6.18

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données :  `atvcommande`
--

-- --------------------------------------------------------

--
-- Structure de la table `chantiers`
--

CREATE TABLE `chantiers` (
  `ID_chantier` int(11) NOT NULL,
  `nom` varchar(255) NOT NULL,
  `nom_client` varchar(255) NOT NULL,
  `adresse_rue` varchar(255) NOT NULL,
  `adresse_ville` varchar(255) NOT NULL,
  `adresse_cp` varchar(255) NOT NULL,
  `date_recep` varchar(255) NOT NULL,
  `date_marche` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Contenu de la table `chantiers`
--

INSERT INTO `chantiers` (`ID_chantier`, `nom`, `nom_client`, `adresse_rue`, `adresse_ville`, `adresse_cp`, `date_recep`, `date_marche`) VALUES
(1, 'Giffard', 'Giffard', '35 rue du commandant Kieffer', 'Colleville', '14880', '19/06/2018', '19/06/2018'),
(2, 'Renard', 'Bacheley', '4 Rue Louis Aragon', 'Colombelles', '14460', '27/06/2018', '30/06/2018');

-- --------------------------------------------------------

--
-- Structure de la table `clients`
--

CREATE TABLE `clients` (
  `ID_client` int(11) NOT NULL,
  `nom` varchar(255) NOT NULL,
  `prenom` varchar(255) NOT NULL,
  `adresse_rue` varchar(255) NOT NULL,
  `adresse_ville` varchar(255) NOT NULL,
  `adresse_cp` varchar(255) NOT NULL,
  `tel_fix` varchar(255) NOT NULL,
  `tel_port` varchar(255) NOT NULL,
  `mail` varchar(255) NOT NULL,
  `statut` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Contenu de la table `clients`
--

INSERT INTO `clients` (`ID_client`, `nom`, `prenom`, `adresse_rue`, `adresse_ville`, `adresse_cp`, `tel_fix`, `tel_port`, `mail`, `statut`) VALUES
(1, 'Bacheley', 'Thomas', '4 Rue louis aragon', 'Colombelles', '14460', '0231723526', '0659833253', 'yweelon@gmail.com', 'Particulier');

-- --------------------------------------------------------

--
-- Structure de la table `commandes`
--

CREATE TABLE `commandes` (
  `ID_commande` int(11) NOT NULL,
  `numero` varchar(255) NOT NULL,
  `fournisseur` varchar(255) NOT NULL,
  `client` varchar(255) NOT NULL,
  `chantier` varchar(255) NOT NULL,
  `chantier_ville` varchar(255) NOT NULL,
  `chantier_rue` varchar(255) NOT NULL,
  `date_livraison` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Contenu de la table `commandes`
--

INSERT INTO `commandes` (`ID_commande`, `numero`, `fournisseur`, `client`, `chantier`, `chantier_ville`, `chantier_rue`, `date_livraison`) VALUES
(1, '', 'Point P', 'Giffard', 'Giffard', 'Colleville-Montgomery', '35 rue du commandant kieffer', '29/06/2018');

-- --------------------------------------------------------

--
-- Structure de la table `fournisseurs`
--

CREATE TABLE `fournisseurs` (
  `ID_fournisseur` int(11) NOT NULL,
  `nom` varchar(255) NOT NULL,
  `mail` varchar(255) NOT NULL,
  `tel` varchar(255) NOT NULL,
  `adresse_rue` varchar(255) NOT NULL,
  `adresse_ville` varchar(255) NOT NULL,
  `adresse_cp` varchar(255) NOT NULL,
  `site_web` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Contenu de la table `fournisseurs`
--

INSERT INTO `fournisseurs` (`ID_fournisseur`, `nom`, `mail`, `tel`, `adresse_rue`, `adresse_ville`, `adresse_cp`, `site_web`) VALUES
(1, 'Point P', 'CAEN@POINTP.FR', '0231727100', '110 Cours Montalivet', 'Caen', '14000', 'https://www.pointp.fr/'),
(2, 'Point P', 'COURSEULLES@POINTP.FR', '0231361010', 'ZI Route de reviers', 'Courseulles sur mer', '14470', 'https://www.pointp.fr/'),
(3, 'Point P', 'FLEURY@POINTP.FR', '0231842000', '1 rue des carriers', 'Fleury sur orne', '14123', 'https://www.pointp.fr/');

-- --------------------------------------------------------

--
-- Structure de la table `produits`
--

CREATE TABLE `produits` (
  `ID_produit` int(11) NOT NULL,
  `nom` varchar(255) NOT NULL,
  `caracteristique` varchar(255) NOT NULL,
  `type_produit` varchar(255) NOT NULL,
  `type_grain` varchar(255) NOT NULL,
  `systeme` varchar(255) NOT NULL,
  `support` varchar(255) NOT NULL,
  `fournisseur` varchar(255) NOT NULL,
  `fabricant` varchar(255) NOT NULL,
  `consomation` varchar(255) NOT NULL,
  `epaisseur_Rth` varchar(255) NOT NULL,
  `prix_unitaire` varchar(255) NOT NULL,
  `unite_grandeur` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Contenu de la table `produits`
--

INSERT INTO `produits` (`ID_produit`, `nom`, `caracteristique`, `type_produit`, `type_grain`, `systeme`, `support`, `fournisseur`, `fabricant`, `consomation`, `epaisseur_Rth`, `prix_unitaire`, `unite_grandeur`) VALUES
(1, 'OZÉ', 'semi-allégé', 'OC2', 'GF', 'Monocouches', 'RT2 RT3', 'Point P', 'PRB', '15mm - 24kg/m²', '', '20', 'sac'),
(2, '85', 'semi-lourd', 'OC3', 'GM', 'Monocouche', 'parpaings/RT3', 'Point P', 'PRB', '15mm - 24kg/m²', '', '34', 'sac'),
(3, 'PSE R TH 38', 'Rainuré Blanc', '', '', 'ITE', 'Mur extérieur', 'Point P', 'PRB', '1,05m²', '140mm - 3,70m².K/W', '', 'Panneau');

-- --------------------------------------------------------

--
-- Structure de la table `ref_nuancier`
--

CREATE TABLE `ref_nuancier` (
  `ID_nuancier` int(11) NOT NULL,
  `teinte` varchar(255) NOT NULL,
  `numero` varchar(255) NOT NULL,
  `coefficient` varchar(255) NOT NULL,
  `gamme` varchar(255) NOT NULL,
  `plus_value` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Contenu de la table `ref_nuancier`
--

INSERT INTO `ref_nuancier` (`ID_nuancier`, `teinte`, `numero`, `coefficient`, `gamme`, `plus_value`) VALUES
(1, 'ALEXANDRIE', '465', '<0,7', 'traditionnel', ''),
(2, 'AMAZONIE', '118', '<0,7', 'traditionnel', ''),
(3, 'ANTALYA', '002', '<0,7', 'traditionnel', ''),
(4, 'ANTHEOR', '031', '<0,7', 'traditionnel', ''),
(5, 'AQUITAINE', '019', '<0,7', 'traditionnel', ''),
(6, 'ARCTIQUE', '220', '<0,7', 'traditionnel', ''),
(7, 'ARDECHE', '044', '<0,7', 'traditionnel', ''),
(8, 'ATHENE', '692', '<0,7', 'traditionnel', ''),
(9, 'AZAY LE RIDEAU', '026', '<0,7', 'traditionnel', ''),
(10, 'BAHIA', '752', '<0,7', 'traditionnel', ''),
(11, 'BERMUDES', '097', '<0,7', 'traditionnel', ''),
(12, 'BERRY', '901', '<0,7', 'traditionnel', ''),
(13, 'BLANC DE LA COTE', '049', '<0,7', 'traditionnel', ''),
(14, 'BLANC DE NOIRMOUTIER', '013', '<0,7', 'traditionnel', ''),
(15, 'BOCAGE VENDEEN', '010', '<0,7', 'traditionnel', ''),
(16, 'BREHAT', '854', '<0,7', 'traditionnel', ''),
(17, 'BURGOS', '894', '<0,7', 'traditionnel', ''),
(18, 'CALEDONIE', '191', '<0,7', 'traditionnel', ''),
(19, 'CALIFORNIE', '253', '<0,7', 'traditionnel', ''),
(20, 'CAMARGUE', '037', '<0,7', 'traditionnel', ''),
(21, 'CAP CORSE', '034', '<0,7', 'traditionnel', ''),
(22, 'CARNAC', '039', '<0,7', 'traditionnel', ''),
(23, 'CARTHAGE', '446', '<0,7', 'traditionnel', ''),
(24, 'CEVENNES', '040', '<0,7', 'traditionnel', ''),
(25, 'CEYLAN', '755', '<0,7', 'traditionnel', ''),
(27, 'CHAMPAGNE', '017', '<0,7', 'traditionnel', ''),
(28, 'CHEVERNY', '014', '<0,7', 'traditionnel', ''),
(29, 'COIMBRA', '804', '<0,7', 'traditionnel', ''),
(30, 'COLLIOURE', '028', '<0,7', 'traditionnel', ''),
(32, 'CHAMBORD', '027', '<0,7', 'traditionnel', ''),
(33, 'CONNEMARA', '884', '<0,7', 'traditionnel', ''),
(34, 'COPACABANA', '611', '<0,7', 'traditionnel', ''),
(35, 'CORDOUE', '184', '<0,7', 'traditionnel', ''),
(36, 'CORINTHE', '589', '<0,7', 'traditionnel', ''),
(37, 'COTE D\'AZUR', '016', '<0,7', 'traditionnel', ''),
(38, 'COTE D\'EMERAUDE', '043', '<0,7', 'traditionnel', ''),
(39, 'COTE D\'OPALE', '045', '<0,7', 'traditionnel', ''),
(40, 'COTE D\'OR', '029', '<0,7', 'traditionnel', ''),
(41, 'FINISTERE', '041', '<0,7', 'traditionnel', ''),
(42, 'FORT DE FRANCE', '398', '<0,7', 'traditionnel', ''),
(43, 'FRANCHE COMTE', '023', '<0,7', 'traditionnel', ''),
(44, 'GIBRALTAR', '757', '<0,7', 'traditionnel', ''),
(45, 'GRES DALSACE', '036', '<0,7', 'traditionnel', ''),
(46, 'GRIS OUESSANT', '009', '<0,7', 'traditionnel', ''),
(47, 'GUERANDE', '721', '<0,7', 'traditionnel', ''),
(48, 'GUIZEH', '413', '<0,7', 'traditionnel', ''),
(49, 'GUYANE', '762', '<0,7', 'traditionnel', ''),
(50, 'HAWAI', '948', '<0,7', 'traditionnel', ''),
(51, 'ILE D\'YEU', '046', '<0,7', 'traditionnel', ''),
(52, 'ILE DE FRANCE', '018', '<0,7', 'traditionnel', ''),
(53, 'ISLANDE', '383', '<0,7', 'traditionnel', ''),
(54, 'JAUNE TOURAINE', '003', '<0,7', 'traditionnel', ''),
(55, 'JERSEY', '783', '<0,7', 'traditionnel', ''),
(56, 'KENYA', '518', '<0,7', 'traditionnel', ''),
(57, 'LASCAUX', '038', '<0,7', 'traditionnel', ''),
(58, 'LAVANDOU', '613', '<0,7', 'traditionnel', ''),
(59, 'MALDIVES', '935', '<0,7', 'traditionnel', ''),
(60, 'MALTE', '690', '<0,7', 'traditionnel', ''),
(61, 'MARRAKECH', '990', '<0,7', 'traditionnel', ''),
(62, 'MEDOC', '033', '<0,7', 'traditionnel', ''),
(63, 'MEXICO', '381', '<0,7', 'traditionnel', ''),
(64, 'MIDI PYRENEES', '024', '<0,7', 'traditionnel', ''),
(65, 'BLANC CRISTAL', '', '<0,7', 'traditionnel', ''),
(66, 'NIAGARA', '840', '<0,7', 'traditionnel', ''),
(67, 'OSLO', '588', '<0,7', 'traditionnel', ''),
(68, 'OXFORD', '806', '<0,7', 'traditionnel', ''),
(69, 'PARME', '533', '<0,7', 'traditionnel', ''),
(70, 'PERIGORD', '035', '<0,7', 'traditionnel', ''),
(71, 'PICARDIE', '025', '<0,7', 'traditionnel', ''),
(72, 'PLAINE DE LUÇON', '011', '<0,7', 'traditionnel', ''),
(73, 'RIO', '505', '<0,7', 'traditionnel', ''),
(74, 'ROME', '411', '<0,7', 'traditionnel', ''),
(75, 'ROSE ANJOU', '007', '<0,7', 'traditionnel', ''),
(76, 'ROSE PROVENCE', '004', '<0,7', 'traditionnel', ''),
(77, 'ROUGE ESTEREL', '006', '<0,7', 'traditionnel', ''),
(78, 'ROUGE SOLOGNE', '022', '<0,7', 'traditionnel', ''),
(79, 'ROUSSILLON', '288', '<0,7', 'traditionnel', ''),
(80, 'SAÏGON', '200', '<0,7', 'traditionnel', ''),
(81, 'SAINT TROPEZ', '030', '<0,7', 'traditionnel', ''),
(82, 'TENERE', '933', '<0,7', 'traditionnel', ''),
(83, 'TÉNÉRIFE', '328', '<0,7', 'traditionnel', ''),
(84, 'TERRE DE LANGUEDOC', '021', '<0,7', 'traditionnel', ''),
(85, 'TOLEDE', '865', '<0,7', 'traditionnel', ''),
(86, 'TON PIERRE', '015', '<0,7', 'traditionnel', ''),
(87, 'TON SABLE', '000', '<0,7', 'traditionnel', ''),
(88, 'TRINIDAD', '740', '<0,7', 'traditionnel', ''),
(89, 'VAL DE LOIRE', '020', '<0,7', 'traditionnel', ''),
(90, 'VALLAURIS', '032', '<0,7', 'traditionnel', ''),
(91, 'VALLEE DE SEVRES', '012', '<0,7', 'traditionnel', ''),
(92, 'VERT DAUBRAC', '047', '<0,7', 'traditionnel', ''),
(93, 'VERT MONACO', '005', '<0,7', 'traditionnel', ''),
(94, 'VIEUX TUFFEAU', '008', '<0,7', 'traditionnel', ''),
(95, 'VIRGINIE', '453', '<0,7', 'traditionnel', ''),
(96, 'AUVERGNE', '042', '>0,7', 'traditionnel', ''),
(97, 'BELFAST', '716', '>0,7', 'traditionnel', ''),
(98, 'CAUCASE', '766', '>0,7', 'traditionnel', ''),
(99, 'CUBA', '734', '>0,7', 'traditionnel', ''),
(100, 'VANCOUVER', '524', '>0,7', 'traditionnel', ''),
(101, 'ABIDJAN', '', '>=0,7', 'Sun +', ''),
(102, 'ALICANTE', '', '>=0,7', 'Sun +', ''),
(103, 'CALVI', '', '>=0,7', 'Sun +', ''),
(104, 'CASTRE', '', '>=0,7', 'Sun +', ''),
(105, 'CASTELLANE', '', '>=0,7', 'Sun +', ''),
(106, 'CORK', '', '>=0,7', 'Sun +', ''),
(107, 'DETROIT', '', '>=0,7', 'Sun +', ''),
(108, 'FECAMP', '', '>=0,7', 'Sun +', ''),
(109, 'GALWAY', '', '>=0,7', 'Sun +', ''),
(110, 'HAGUENAU', '', '>=0,7', 'Sun +', ''),
(111, 'HAVANE', '', '>=0,7', 'Sun +', ''),
(112, 'IGOUCHIE', '', '>=0,7', 'Sun +', ''),
(113, 'IRLANDE', '', '>=0,7', 'Sun +', ''),
(114, 'LAGUIOLE', '', '>=0,7', 'Sun +', ''),
(115, 'LECAP', '', '>=0,7', 'Sun +', ''),
(116, 'MANILLE', '', '>=0,7', 'Sun +', ''),
(117, 'MELBOURNE', '', '>=0,7', 'Sun +', ''),
(118, 'MICHIGAN', '', '>=0,7', 'Sun +', ''),
(119, 'MILOS', '', '>=0,7', 'Sun +', ''),
(120, 'NIAMEY', '', '>=0,7', 'Sun +', ''),
(121, 'OBERNAI', '', '>=0,7', 'Sun +', ''),
(122, 'PUY DE DOME', '', '>=0,7', 'Sun +', ''),
(123, 'QUEBEC', '', '>=0,7', 'Sun +', ''),
(124, 'SANTIAGO', '', '>=0,7', 'Sun +', ''),
(125, 'TABASCO', '', '>=0,7', 'Sun +', ''),
(126, 'NEIGE', '', '<0,7', 'traditionnel', ''),
(127, 'SUPER BLANC', '', '<0,7', 'traditionnel', '');

--
-- Index pour les tables exportées
--

--
-- Index pour la table `chantiers`
--
ALTER TABLE `chantiers`
  ADD PRIMARY KEY (`ID_chantier`);

--
-- Index pour la table `clients`
--
ALTER TABLE `clients`
  ADD PRIMARY KEY (`ID_client`);

--
-- Index pour la table `commandes`
--
ALTER TABLE `commandes`
  ADD PRIMARY KEY (`ID_commande`);

--
-- Index pour la table `fournisseurs`
--
ALTER TABLE `fournisseurs`
  ADD PRIMARY KEY (`ID_fournisseur`);

--
-- Index pour la table `produits`
--
ALTER TABLE `produits`
  ADD PRIMARY KEY (`ID_produit`);

--
-- Index pour la table `ref_nuancier`
--
ALTER TABLE `ref_nuancier`
  ADD PRIMARY KEY (`ID_nuancier`);

--
-- AUTO_INCREMENT pour les tables exportées
--

--
-- AUTO_INCREMENT pour la table `chantiers`
--
ALTER TABLE `chantiers`
  MODIFY `ID_chantier` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;
--
-- AUTO_INCREMENT pour la table `clients`
--
ALTER TABLE `clients`
  MODIFY `ID_client` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT pour la table `commandes`
--
ALTER TABLE `commandes`
  MODIFY `ID_commande` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT pour la table `fournisseurs`
--
ALTER TABLE `fournisseurs`
  MODIFY `ID_fournisseur` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;
--
-- AUTO_INCREMENT pour la table `ref_nuancier`
--
ALTER TABLE `ref_nuancier`
  MODIFY `ID_nuancier` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=128;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
