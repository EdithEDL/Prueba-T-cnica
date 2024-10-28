-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 28-10-2024 a las 17:46:18
-- Versión del servidor: 10.4.32-MariaDB
-- Versión de PHP: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `prueba`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `product`
--

CREATE TABLE `product` (
  `id_producto` int(11) NOT NULL,
  `nombre` varchar(45) NOT NULL,
  `precio` double NOT NULL,
  `descripcion` varchar(45) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- RELACIONES PARA LA TABLA `product`:
--

--
-- Volcado de datos para la tabla `product`
--

INSERT INTO `product` (`id_producto`, `nombre`, `precio`, `descripcion`) VALUES
(1, 'Computadoras Mac', 8999, '16 G de ram'),
(2, 'Iphone 13', 10599, '32 de G '),
(3, 'Reloj Inteligente ', 3500, 'Impermeable'),
(4, 'Motorola Moto', 5879, '64 G');

-- --------------------------------------------------------

--
-- Estructura Stand-in para la vista `productosvendidos`
-- (Véase abajo para la vista actual)
--
CREATE TABLE `productosvendidos` (
`id_venta` int(11)
,`nombre` varchar(45)
,`precio` double
,`cantidad` int(11)
,`monto_total` decimal(10,0)
,`fecha` date
);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `productovendido`
--

CREATE TABLE `productovendido` (
  `id` int(11) NOT NULL,
  `id_venta` int(11) NOT NULL,
  `id_producto` int(11) NOT NULL,
  `cantidad` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- RELACIONES PARA LA TABLA `productovendido`:
--   `id_venta`
--       `venta` -> `id_venta`
--   `id_producto`
--       `product` -> `id_producto`
--

--
-- Volcado de datos para la tabla `productovendido`
--

INSERT INTO `productovendido` (`id`, `id_venta`, `id_producto`, `cantidad`) VALUES
(1, 1, 3, 3),
(2, 2, 1, 2),
(3, 3, 4, 5);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `venta`
--

CREATE TABLE `venta` (
  `id_venta` int(11) NOT NULL,
  `fecha` date NOT NULL,
  `monto_total` decimal(10,0) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- RELACIONES PARA LA TABLA `venta`:
--

--
-- Volcado de datos para la tabla `venta`
--

INSERT INTO `venta` (`id_venta`, `fecha`, `monto_total`) VALUES
(1, '2024-10-28', 10500),
(2, '2024-10-28', 17998),
(3, '2024-10-28', 29395);

-- --------------------------------------------------------

--
-- Estructura para la vista `productosvendidos`
--
DROP TABLE IF EXISTS `productosvendidos`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `productosvendidos`  AS SELECT `v`.`id_venta` AS `id_venta`, `p`.`nombre` AS `nombre`, `p`.`precio` AS `precio`, `pv`.`cantidad` AS `cantidad`, `v`.`monto_total` AS `monto_total`, `v`.`fecha` AS `fecha` FROM ((`venta` `v` join `productovendido` `pv` on(`v`.`id_venta` = `pv`.`id_venta`)) join `product` `p` on(`pv`.`id_producto` = `p`.`id_producto`)) ;

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `product`
--
ALTER TABLE `product`
  ADD PRIMARY KEY (`id_producto`);

--
-- Indices de la tabla `productovendido`
--
ALTER TABLE `productovendido`
  ADD PRIMARY KEY (`id`),
  ADD KEY `fk_productos` (`id_producto`),
  ADD KEY `fk_idVenta` (`id_venta`);

--
-- Indices de la tabla `venta`
--
ALTER TABLE `venta`
  ADD PRIMARY KEY (`id_venta`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `product`
--
ALTER TABLE `product`
  MODIFY `id_producto` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT de la tabla `productovendido`
--
ALTER TABLE `productovendido`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT de la tabla `venta`
--
ALTER TABLE `venta`
  MODIFY `id_venta` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `productovendido`
--
ALTER TABLE `productovendido`
  ADD CONSTRAINT `fk_idVenta` FOREIGN KEY (`id_venta`) REFERENCES `venta` (`id_venta`),
  ADD CONSTRAINT `fk_productos` FOREIGN KEY (`id_producto`) REFERENCES `product` (`id_producto`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
