


/************ Update: Tables ***************/

/******************** Add Table: kleur ************************/

/* Build Table Structure */
CREATE TABLE kleur
(
	kleur_id INTEGER NOT NULL IDENTITY (1, 1),
	kleur_naam VARCHAR(50) NOT NULL,
	kleur_hexcode VARCHAR(10) NOT NULL
);

/* Table Items: kleur */
ALTER TABLE kleur ADD CONSTRAINT pkkleur
	PRIMARY KEY (kleur_id);

/******************** Add Table: pakket ************************/

/* Build Table Structure */
CREATE TABLE pakket
(
	pakket_id INTEGER NOT NULL IDENTITY (1, 1),
	pakket_naam VARCHAR(100) NOT NULL,
	pakket_lengte INTEGER NOT NULL,
	pakket_breedte INTEGER NOT NULL,
	pakket_hoogte INTEGER NOT NULL,
	pakket_prijs DECIMAL(10, 2) NOT NULL,
	kleur_id INTEGER NOT NULL,
	thema_id INTEGER NOT NULL
);

/* Table Items: pakket */
ALTER TABLE pakket ADD CONSTRAINT pkpakket
	PRIMARY KEY (pakket_id);

/******************** Add Table: pakket_product ************************/

/* Build Table Structure */
CREATE TABLE pakket_product
(
	pp_pakket_id INTEGER NOT NULL,
	pp_product_id INTEGER NOT NULL
);

/******************** Add Table: product ************************/

/* Build Table Structure */
CREATE TABLE product
(
	product_id INTEGER NOT NULL IDENTITY (1, 1),
	product_naam VARCHAR(100) NOT NULL,
	product_beschrijving VARCHAR(250) NOT NULL,
	product_lengte INTEGER NOT NULL,
	product_hoogte INTEGER NOT NULL,
	product_breedte INTEGER NOT NULL,
	product_prijs BIGINT NOT NULL
);

/* Table Items: product */
ALTER TABLE product ADD CONSTRAINT pkproduct
	PRIMARY KEY (product_id);

/******************** Add Table: thema ************************/

/* Build Table Structure */
CREATE TABLE thema
(
	thema_id INTEGER NOT NULL IDENTITY (1, 1),
	thema_naam VARCHAR(100) NOT NULL,
	thema_patroon VARCHAR(100) NOT NULL
);

/* Table Items: thema */
ALTER TABLE thema ADD CONSTRAINT pkthema
	PRIMARY KEY (thema_id);


/************ Add Foreign Keys to Database ***************/

/************ Foreign Key: fk_pakket_kleur ***************/
ALTER TABLE pakket ADD CONSTRAINT fk_pakket_kleur
	FOREIGN KEY (kleur_id) REFERENCES kleur (kleur_id);

/************ Foreign Key: fk_pakket_thema ***************/
ALTER TABLE pakket ADD CONSTRAINT fk_pakket_thema
	FOREIGN KEY (thema_id) REFERENCES thema (thema_id);

/************ Foreign Key: fk_pakket_product_pakket ***************/
ALTER TABLE pakket_product ADD CONSTRAINT fk_pakket_product_pakket
	FOREIGN KEY (pp_pakket_id) REFERENCES pakket (pakket_id);

/************ Foreign Key: fk_pakket_product_product ***************/
ALTER TABLE pakket_product ADD CONSTRAINT fk_pakket_product_product
	FOREIGN KEY (pp_product_id) REFERENCES product (product_id);