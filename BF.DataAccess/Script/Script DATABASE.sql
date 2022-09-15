CREATE SCHEMA IF NOT EXISTS bet;

CREATE SEQUENCE bet.canal_id_seq START WITH 1 INCREMENT BY 1;

CREATE SEQUENCE bet.equipo_id_seq START WITH 1 INCREMENT BY 1;

CREATE SEQUENCE bet.grupo_id_seq START WITH 1 INCREMENT BY 1;

CREATE SEQUENCE bet.jornada_id_seq START WITH 1 INCREMENT BY 1;

CREATE SEQUENCE bet.parametro_id_seq START WITH 1 INCREMENT BY 1;

CREATE SEQUENCE bet.participante_canal_id_seq START WITH 1 INCREMENT BY 1;

CREATE SEQUENCE bet.participante_id_seq START WITH 1 INCREMENT BY 1;

CREATE SEQUENCE bet.partido_equipo_id_seq START WITH 1 INCREMENT BY 1;

CREATE SEQUENCE bet.partido_id_seq START WITH 1 INCREMENT BY 1;

CREATE SEQUENCE bet.pronostico_equipo_id_seq START WITH 1 INCREMENT BY 1;

CREATE SEQUENCE bet.pronostico_id_seq START WITH 1 INCREMENT BY 1;

CREATE SEQUENCE bet.pronostico_partido_id_seq START WITH 1 INCREMENT BY 1;

CREATE  TABLE bet.canal ( 
	id                   integer DEFAULT nextval('bet.canal_id_seq'::regclass) NOT NULL  ,
	nombre               varchar(40)  NOT NULL  ,
	limite               integer  NOT NULL  ,
	clave                varchar(50)  NOT NULL  ,
	estado               varchar(15)  NOT NULL  ,
	fecha_creacion       timestamp  NOT NULL  ,
	fecha_modificacion   timestamp    ,
	CONSTRAINT pk_canal PRIMARY KEY ( id )
 );

CREATE  TABLE bet.grupo ( 
	id                   integer DEFAULT nextval('bet.grupo_id_seq'::regclass) NOT NULL  ,
	nombre               varchar(40)  NOT NULL  ,
	orden                integer  NOT NULL  ,
	estado               varchar(15)  NOT NULL  ,
	fecha_creacion       timestamp  NOT NULL  ,
	fecha_modificacion   timestamp    ,
	CONSTRAINT pk_grupo PRIMARY KEY ( id )
 );

CREATE  TABLE bet.jornada ( 
	id                   integer DEFAULT nextval('bet.jornada_id_seq'::regclass) NOT NULL  ,
	nombre               varchar(40)  NOT NULL  ,
	estado               varchar(15)  NOT NULL  ,
	fecha_creacion       timestamp  NOT NULL  ,
	fecha_modificacion   timestamp    ,
	CONSTRAINT pk_jornada PRIMARY KEY ( id )
 );

CREATE  TABLE bet.parametro ( 
	id                   integer DEFAULT nextval('bet.parametro_id_seq'::regclass) NOT NULL  ,
	nombre               varchar(40)  NOT NULL  ,
	valor                varchar(20)  NOT NULL  ,
	tipodato             varchar(20)  NOT NULL  ,
	grupo                varchar(50)  NOT NULL  ,
	orden                integer  NOT NULL  ,
	estado               varchar(15)  NOT NULL  ,
	fecha_creacion       timestamp  NOT NULL  ,
	usuario_creacion     varchar(15)    ,
	CONSTRAINT pk_parametro PRIMARY KEY ( id )
 );

CREATE  TABLE bet.participante ( 
	id                   integer DEFAULT nextval('bet.participante_id_seq'::regclass) NOT NULL  ,
	usuario              varchar(40)  NOT NULL  ,
	clave                varchar(20)  NOT NULL  ,
	email                varchar(50)  NOT NULL  ,
	estado               varchar(15)  NOT NULL  ,
	imagen               text    ,
	fecha_creacion       timestamp  NOT NULL  ,
	fecha_modificacion   timestamp    ,
	CONSTRAINT pk_participante PRIMARY KEY ( id )
 );

CREATE  TABLE bet.participante_canal ( 
	id                   integer DEFAULT nextval('bet.participante_canal_id_seq'::regclass) NOT NULL  ,
	id_participante      integer  NOT NULL  ,
	id_canal             integer  NOT NULL  ,
	orden                integer  NOT NULL  ,
	estado               varchar(15)  NOT NULL  ,
	fecha_creacion       timestamp  NOT NULL  ,
	fecha_modificacion   timestamp    ,
	CONSTRAINT pk_participante_canal PRIMARY KEY ( id ),
	CONSTRAINT participante_canal_id_canal_fkey FOREIGN KEY ( id_canal ) REFERENCES bet.canal( id )   ,
	CONSTRAINT participante_canal_id_participante_fkey FOREIGN KEY ( id_participante ) REFERENCES bet.participante( id )   
 );

CREATE  TABLE bet.partido ( 
	id                   integer DEFAULT nextval('bet.partido_id_seq'::regclass) NOT NULL  ,
	fecha                timestamp  NOT NULL  ,
	hora                 varchar(20)  NOT NULL  ,
	lugar                varchar(50)  NOT NULL  ,
	estado               varchar(15)  NOT NULL  ,
	empate               boolean  NOT NULL  ,
	id_jornada           integer  NOT NULL  ,
	fecha_creacion       timestamp  NOT NULL  ,
	fecha_modificacion   timestamp    ,
	CONSTRAINT pk_partido PRIMARY KEY ( id ),
	CONSTRAINT partido_id_jornada_fkey FOREIGN KEY ( id_jornada ) REFERENCES bet.jornada( id )   
 );

CREATE  TABLE bet.pronostico ( 
	id                   integer DEFAULT nextval('bet.pronostico_id_seq'::regclass) NOT NULL  ,
	nombre               varchar(40)  NOT NULL  ,
	ordinal              integer  NOT NULL  ,
	estado               varchar(15)  NOT NULL  ,
	puntos               integer    ,
	id_participante_canal integer  NOT NULL  ,
	fecha_creacion       timestamp  NOT NULL  ,
	fecha_modificacion   timestamp    ,
	CONSTRAINT pk_pronostico PRIMARY KEY ( id ),
	CONSTRAINT pronostico_id_participante_canal_fkey FOREIGN KEY ( id_participante_canal ) REFERENCES bet.participante_canal( id )   
 );

CREATE  TABLE bet.pronostico_partido ( 
	id                   integer DEFAULT nextval('bet.pronostico_partido_id_seq'::regclass) NOT NULL  ,
	id_pronostico        integer  NOT NULL  ,
	id_partido           integer  NOT NULL  ,
	estado               varchar(15)  NOT NULL  ,
	fecha_creacion       timestamp  NOT NULL  ,
	fecha_modificacion   timestamp    ,
	empate               boolean  NOT NULL  ,
	CONSTRAINT pk_pronostico_partido PRIMARY KEY ( id ),
	CONSTRAINT pronostico_partido_id_partido_fkey FOREIGN KEY ( id_partido ) REFERENCES bet.partido( id )   ,
	CONSTRAINT pronostico_partido_id_pronostico_fkey FOREIGN KEY ( id_pronostico ) REFERENCES bet.pronostico( id )   
 );

CREATE  TABLE bet.equipo ( 
	id                   integer DEFAULT nextval('bet.equipo_id_seq'::regclass) NOT NULL  ,
	nombre               varchar(40)  NOT NULL  ,
	pais                 varchar(20)  NOT NULL  ,
	tipo                 varchar(50)  NOT NULL  ,
	id_grupo             integer  NOT NULL  ,
	fecha_creacion       timestamp  NOT NULL  ,
	fecha_modificacion   timestamp    ,
	imagen               text    ,
	CONSTRAINT pk_equipo PRIMARY KEY ( id ),
	CONSTRAINT equipo_id_grupo_fkey FOREIGN KEY ( id_grupo ) REFERENCES bet.grupo( id )   
 );

CREATE  TABLE bet.partido_equipo ( 
	id                   integer DEFAULT nextval('bet.partido_equipo_id_seq'::regclass) NOT NULL  ,
	id_equipo            integer  NOT NULL  ,
	id_partido           integer  NOT NULL  ,
	cantidad_gol         integer  NOT NULL  ,
	estado               varchar(15)  NOT NULL  ,
	fecha_creacion       timestamp  NOT NULL  ,
	fecha_modificacion   timestamp    ,
	CONSTRAINT pk_partido_equipo PRIMARY KEY ( id ),
	CONSTRAINT partido_equipo_id_equipo_fkey FOREIGN KEY ( id_equipo ) REFERENCES bet.equipo( id )   ,
	CONSTRAINT partido_equipo_id_partido_fkey FOREIGN KEY ( id_partido ) REFERENCES bet.partido( id )   
 );

CREATE  TABLE bet.pronostico_equipo ( 
	id                   integer DEFAULT nextval('bet.pronostico_equipo_id_seq'::regclass) NOT NULL  ,
	id_pronostico_partido integer  NOT NULL  ,
	id_partido_equipo    integer  NOT NULL  ,
	estado               varchar(15)  NOT NULL  ,
	fecha_creacion       timestamp  NOT NULL  ,
	fecha_modificacion   timestamp    ,
	cantidad_gol         integer  NOT NULL  ,
	CONSTRAINT pk_pronostico_equipo PRIMARY KEY ( id ),
	CONSTRAINT pronostico_equipo_id_partido_equipo_fkey FOREIGN KEY ( id_partido_equipo ) REFERENCES bet.partido_equipo( id )   ,
	CONSTRAINT pronostico_equipo_id_pronostico_partido_fkey FOREIGN KEY ( id_pronostico_partido ) REFERENCES bet.pronostico_partido( id )   
 );

CREATE OR REPLACE FUNCTION bet.crear_participante2(pstrusuario text, pstrclave text, pstremail text, pstrimagen text)
 RETURNS SETOF bet.participante
 LANGUAGE sql
AS $function$
 INSERT INTO bet.participante ( usuario
							  , clave
							  , email
							  , estado
							  , imagen
							  , fecha_creacion
							  , fecha_modificacion)
 	  				VALUES( pStrUsuario
							 , pStrClave
							 , pStrEmail
							 , 'ACTIVO'
							 , pStrImagen
							 , NOW()
							 , NULL );
    --COMMIT;                             
 
 SELECT *
 FROM bet.participante;
$function$
;

CREATE OR REPLACE FUNCTION bet.obtener_canales()
 RETURNS SETOF bet.canal
 LANGUAGE sql
AS $function$ 
  SELECT *
  FROM bet.canal
  where estado = 'ACTIVO';
$function$
;

CREATE OR REPLACE FUNCTION bet.obtener_canales_por_participante(p_id_participante integer)
 RETURNS SETOF bet.canal
 LANGUAGE sql
AS $function$ 
 
  SELECT *
  FROM bet.canal
  WHERE id in (SELECT id_canal
			   FROM bet.participante_canal
			   WHERE id_participante=p_id_participante);
		
$function$
;

CREATE OR REPLACE FUNCTION bet.obtener_jornadas()
 RETURNS SETOF bet.jornada
 LANGUAGE sql
AS $function$ 
  SELECT *
  FROM bet.jornada
  ORDER BY 1 DESC;
$function$
;

CREATE OR REPLACE FUNCTION bet.obtener_partidos_x_jornada(p_id_jornada integer)
 RETURNS TABLE(id_partido integer, estado_partido character varying, empate boolean, fecha_partido timestamp without time zone, hora_partido character varying, lugar character varying, cantidad_gol integer, nombre_equipo character varying, pais_equipo character varying, tipo_equipo character varying, id_grupo integer, id_partido_equipo integer)
 LANGUAGE plpgsql
AS $function$ 
BEGIN 
	RETURN QUERY SELECT p.id as id_partido 
					  , p.estado as estado_partido 
					  , p.empate 
					  , p.fecha as fecha_partido 
					  , p.hora as hora_partido 
					  , p.lugar 
					  , e.cantidad_gol 
					  , eq.nombre 
					  , eq.pais 
					  , eq.tipo 
					  , eq.id_grupo 
					  , e.id as id_partido_equipo	
				 FROM bet.partido p 
					INNER JOIN bet.partido_equipo e 
							ON p.id = e.id_partido 
				    INNER JOIN bet.equipo eq 
							ON e.id_equipo = eq.id 
				 WHERE p.id_jornada = p_id_jornada; 
END; $function$
;

CREATE OR REPLACE FUNCTION bet.obtener_pronostico_partido(p_id_pronostico integer)
 RETURNS TABLE(id_pronostico integer, id_partido integer, estado_pronostico_partido character varying, fecha_creacion timestamp without time zone, empate boolean, id_pronostico_equipo integer, id_pronostico_partido integer, id_partido_equipo integer, estado_pronostico_equipo character varying, cantidad_gol integer)
 LANGUAGE plpgsql
AS $function$
 begin 
  RETURN QUERY SELECT p.id_pronostico
                     , p.id_partido
                     , p.estado as estado_pronostico_partido
                     , p.fecha_creacion
                     , p.empate
                     , pe.id
                     , pe.id_pronostico_partido
                     , pe.id_partido_equipo
                     , pe.estado as estado_pronostico_equipo                     
                     , pe.cantidad_gol
                FROM bet.pronostico_partido p
                  INNER JOIN bet.pronostico_equipo pe
                          ON p.id = pe.id_pronostico_partido
                WHERE p.id_pronostico = p_id_pronostico;
end; $function$
;

CREATE OR REPLACE FUNCTION bet.obtener_pronosticos_x_canal(p_id_canal integer)
 RETURNS SETOF bet.pronostico
 LANGUAGE sql
AS $function$ 
  SELECT *
  FROM bet.pronostico
  where id_participante_canal IN (SELECT id 
								FROM bet.participante_canal
								WHERE id_canal = p_id_canal
							      AND estado= 'ACTIVO')
	AND estado = 'ACTIVO';
$function$
;

CREATE OR REPLACE FUNCTION bet.obtener_pronosticos_x_canal_participante(p_id_participante integer, p_id_canal integer)
 RETURNS SETOF bet.pronostico
 LANGUAGE sql
AS $function$ 
  SELECT *
  FROM bet.pronostico
  where id_participante_canal IN (SELECT id 
								FROM bet.participante_canal
								WHERE id_participante=p_id_participante
								  AND id_canal = p_id_canal
							      AND estado= 'ACTIVO')
	AND estado = 'ACTIVO';
$function$
;

CREATE OR REPLACE FUNCTION bet.obtenerpartidos()
 RETURNS SETOF bet.partido
 LANGUAGE sql
AS $function$
  SELECT * 
  FROM bet.partido;
$function$
;

CREATE OR REPLACE FUNCTION bet.registrar_participante_en_canal(p_id_participante integer, p_id_canal integer)
 RETURNS character varying
 LANGUAGE plpgsql
AS $function$ 
 DECLARE
  l_id_participante_canal integer;
  l_cantidad_registro integer;
  l_resultado character varying;
 BEGIN
    l_resultado:='BF000';
    l_cantidad_registro:=0;
  SELECT count(*) into l_cantidad_registro
  FROM bet.canal
  WHERE id=p_id_canal;
  IF l_cantidad_registro=0 THEN 
    l_resultado:='BF004|No existe el codigo de canal ingresado'; --No existe el codigo de canal ingresado
    return l_resultado;
  END IF;
    SELECT count(*) into l_cantidad_registro
  FROM bet.participante
  WHERE id=p_id_participante;
  IF l_cantidad_registro=0 THEN 
    l_resultado:='BF003|No existe el codigo de participante '; --No existe el codigo de participante 
    return l_resultado;
  END IF;
    
    SELECT count(*) into l_cantidad_registro
  FROM bet.participante_canal
  WHERE id_participante=p_id_participante
    AND id_canal=p_id_canal;
    IF l_cantidad_registro>0 THEN 
       l_resultado:='BF002|El participante ya existe en el canal asignado';--EL PARTICIPANTE YA EXISTE EN EL CANAL ASIGNADO
    ELSE 
        INSERT INTO bet.participante_canal ( id_participante
                                    , id_canal
                                    , orden
                                    , estado
                                    , fecha_creacion
                                    , fecha_modificacion)
                            VALUES   (  p_id_participante
                                    , p_id_canal
                                    , 1
                                    , 'ACTIVO'
                                    , NOW()
                                    , NULL);
    END IF;
  
  return l_resultado;
END;
$function$
;

CREATE OR REPLACE FUNCTION bet.registrar_pronostico(p_dato_json text)
 RETURNS character varying
 LANGUAGE plpgsql
AS $function$ 
DECLARE
	l_int_cod_canal  integer;
	l_nombre_canal   varchar;
	l_partidos	   varchar;
	l_partido_equipo integer;
	l_cantidad_gol   integer;
	l_resultado	  varchar;
	dato_partido	 jsonb;
	dato_equipo	  jsonb;
	l_id_pronostico  integer;
	l_id_pronostico_partido integer;
	l_id_partido     integer;
    l_empate     boolean;
BEGIN 
	l_resultado :='';
	SELECT p_dato_json::json-> 'id_participante_canal' into l_int_cod_canal;
	SELECT p_dato_json::json-> 'nombre' into l_nombre_canal;
	SELECT p_dato_json::json-> 'partidos' into l_partidos; 
	INSERT INTO  bet.pronostico(nombre, ordinal, estado, puntos, id_participante_canal, fecha_creacion, fecha_modificacion)
    					values(l_nombre_canal,1,'ACTIVO',0,l_int_cod_canal,NOW(),NULL) RETURNING id INTO l_id_pronostico;
   
    FOR dato_partido IN (SELECT json_array_elements((SELECT p_dato_json::json-> 'partidos')))
	LOOP
		SELECT dato_partido::json-> 'id_partido' into l_id_partido;
        SELECT dato_partido::json-> 'empate' into l_empate;
		INSERT INTO  bet.pronostico_partido(id_pronostico, id_partido, estado, fecha_creacion, fecha_modificacion, empate)
								VALUES(l_id_pronostico,l_id_partido,'ACTIVO',NOW(),NULL,l_empate)RETURNING id INTO l_id_pronostico_partido;
		FOR dato_equipo IN (SELECT * FROM json_array_elements((dato_partido::json-> 'partido_equipos')))
		LOOP
				SELECT dato_equipo::json-> 'id_partido_equipo' into l_partido_equipo;
			    SELECT dato_equipo::json-> 'cantidad_gol' into l_cantidad_gol;
			--	l_resultado := l_resultado||' '||l_partido_equipo||' '||l_cantidad_gol;
				INSERT INTO bet.pronostico_equipo( id_pronostico_partido, id_partido_equipo, estado, fecha_creacion, fecha_modificacion, cantidad_gol)
										VALUES(l_id_pronostico_partido,l_partido_equipo,'ACTIVO',NOW(),NULL,l_cantidad_gol);
		END LOOP;
	
	END LOOP;
	 return l_resultado;
	exception	
		when others then 
		--	ROLLBACK;		
			l_resultado:='Error por el cual no se pudo completar la transacción '||SQLERRM||' estate:'||SQLSTATE;
		    return l_resultado;
END; $function$
;

CREATE OR REPLACE FUNCTION bet.validar_participante(p_str_usuario text, p_str_clave text)
 RETURNS SETOF bet.participante
 LANGUAGE sql
AS $function$ 
  SELECT *
  FROM bet.participante
  where usuario = p_str_usuario
	and clave = p_str_clave
	and estado = 'ACTIVO';
$function$
;

CREATE OR REPLACE PROCEDURE bet.create_participante()
 LANGUAGE plpgsql
AS $procedure$
BEGIN
 
 SELECT *  FROM bet.participante;
 --RAISE NOTICE 'emp details for emp 2 is %', result;
 END;
$procedure$
;

INSERT INTO bet.canal( id, nombre, limite, clave, estado, fecha_creacion, fecha_modificacion ) VALUES ( 1, 'AMIGOS UAGRM', 20, '12345', 'ACTIVO', '2022-06-01 02:05:00 a. m.', null);
INSERT INTO bet.grupo( id, nombre, orden, estado, fecha_creacion, fecha_modificacion ) VALUES ( 1, 'GRUPO A', 1, 'ACT', '2022-05-29 10:18:50 p. m.', null);
INSERT INTO bet.grupo( id, nombre, orden, estado, fecha_creacion, fecha_modificacion ) VALUES ( 2, 'GRUPO B', 2, 'ACT', '2022-05-29 11:26:40 p. m.', null);
INSERT INTO bet.grupo( id, nombre, orden, estado, fecha_creacion, fecha_modificacion ) VALUES ( 3, 'GRUPO C', 3, 'ACT', '2022-05-29 11:26:40 p. m.', null);
INSERT INTO bet.grupo( id, nombre, orden, estado, fecha_creacion, fecha_modificacion ) VALUES ( 4, 'GRUPO D', 4, 'ACT', '2022-05-29 11:26:40 p. m.', null);
INSERT INTO bet.grupo( id, nombre, orden, estado, fecha_creacion, fecha_modificacion ) VALUES ( 5, 'GRUPO E', 5, 'ACT', '2022-05-29 11:26:40 p. m.', null);
INSERT INTO bet.grupo( id, nombre, orden, estado, fecha_creacion, fecha_modificacion ) VALUES ( 6, 'GRUPO F', 6, 'ACT', '2022-05-29 11:26:40 p. m.', null);
INSERT INTO bet.grupo( id, nombre, orden, estado, fecha_creacion, fecha_modificacion ) VALUES ( 7, 'GRUPO G', 7, 'ACT', '2022-05-29 11:26:40 p. m.', null);
INSERT INTO bet.grupo( id, nombre, orden, estado, fecha_creacion, fecha_modificacion ) VALUES ( 8, 'GRUPO H', 8, 'ACT', '2022-05-29 11:26:40 p. m.', null);
INSERT INTO bet.jornada( id, nombre, estado, fecha_creacion, fecha_modificacion ) VALUES ( 1, 'JORNADA 1', 'PENDIENTE', '2022-06-01 01:37:25 a. m.', null);
INSERT INTO bet.jornada( id, nombre, estado, fecha_creacion, fecha_modificacion ) VALUES ( 2, 'JORNADA 2', 'PENDIENTE', '2022-06-01 01:38:14 a. m.', null);
INSERT INTO bet.participante( id, usuario, clave, email, estado, imagen, fecha_creacion, fecha_modificacion ) VALUES ( 1, 'nick', '12345', 'nick@gmail.com', 'ACTIVO', null, '2022-06-01 02:01:07 a. m.', null);
INSERT INTO bet.participante( id, usuario, clave, email, estado, imagen, fecha_creacion, fecha_modificacion ) VALUES ( 2, 'jlopez', '12345', 'jhonny@gmail.com', 'ACTIVO', null, '2022-06-02 08:19:25 p. m.', null);
INSERT INTO bet.participante( id, usuario, clave, email, estado, imagen, fecha_creacion, fecha_modificacion ) VALUES ( 3, 'prueba1', '112345', 'ds@gmail.com', 'ACTIVO', null, '2022-06-05 11:43:52 p. m.', null);
INSERT INTO bet.participante( id, usuario, clave, email, estado, imagen, fecha_creacion, fecha_modificacion ) VALUES ( 4, 'prueba2', '112345', 'ds@gmail.com', 'ACTIVO', null, '2022-06-05 11:46:09 p. m.', null);
INSERT INTO bet.participante_canal( id, id_participante, id_canal, orden, estado, fecha_creacion, fecha_modificacion ) VALUES ( 1, 1, 1, 1, 'ACTIVO', '2022-06-01 02:07:09 a. m.', null);
INSERT INTO bet.participante_canal( id, id_participante, id_canal, orden, estado, fecha_creacion, fecha_modificacion ) VALUES ( 2, 2, 1, 1, 'ACTIVO', '2022-09-04 01:55:04 a. m.', null);
INSERT INTO bet.participante_canal( id, id_participante, id_canal, orden, estado, fecha_creacion, fecha_modificacion ) VALUES ( 3, 3, 1, 1, 'ACTIVO', '2022-09-04 01:56:34 a. m.', null);
INSERT INTO bet.partido( id, fecha, hora, lugar, estado, empate, id_jornada, fecha_creacion, fecha_modificacion ) VALUES ( 1, '2022-11-21 12:00:00 a. m.', '17:00', 'Estadio 1', 'PENDIENTE', false, 1, '2022-06-01 01:39:49 a. m.', null);
INSERT INTO bet.partido( id, fecha, hora, lugar, estado, empate, id_jornada, fecha_creacion, fecha_modificacion ) VALUES ( 2, '2022-06-13 08:31:27 p. m.', '10:50', 'algun lugar en QATER', 'PENDIENTE', false, 1, '2022-06-13 08:31:27 p. m.', null);
INSERT INTO bet.pronostico( id, nombre, ordinal, estado, puntos, id_participante_canal, fecha_creacion, fecha_modificacion ) VALUES ( 8, '"pronostico jhonny"', 1, 'ACTIVO', 0, 1, '2022-06-20 12:36:43 p. m.', null);
INSERT INTO bet.pronostico( id, nombre, ordinal, estado, puntos, id_participante_canal, fecha_creacion, fecha_modificacion ) VALUES ( 9, '"Primer pronostico"', 1, 'ACTIVO', 0, 1, '2022-09-01 11:54:31 p. m.', null);
INSERT INTO bet.pronostico( id, nombre, ordinal, estado, puntos, id_participante_canal, fecha_creacion, fecha_modificacion ) VALUES ( 10, '"Primer pronostico"', 1, 'ACTIVO', 0, 1, '2022-09-01 11:54:53 p. m.', null);
INSERT INTO bet.pronostico_partido( id, id_pronostico, id_partido, estado, fecha_creacion, fecha_modificacion, empate ) VALUES ( 4, 8, 1, 'ACTIVO', '2022-06-20 12:36:43 p. m.', null, false);
INSERT INTO bet.pronostico_partido( id, id_pronostico, id_partido, estado, fecha_creacion, fecha_modificacion, empate ) VALUES ( 5, 8, 2, 'ACTIVO', '2022-06-20 12:36:43 p. m.', null, false);
INSERT INTO bet.pronostico_partido( id, id_pronostico, id_partido, estado, fecha_creacion, fecha_modificacion, empate ) VALUES ( 6, 9, 1, 'ACTIVO', '2022-09-01 11:54:31 p. m.', null, false);
INSERT INTO bet.pronostico_partido( id, id_pronostico, id_partido, estado, fecha_creacion, fecha_modificacion, empate ) VALUES ( 7, 9, 2, 'ACTIVO', '2022-09-01 11:54:31 p. m.', null, false);
INSERT INTO bet.pronostico_partido( id, id_pronostico, id_partido, estado, fecha_creacion, fecha_modificacion, empate ) VALUES ( 8, 10, 1, 'ACTIVO', '2022-09-01 11:54:53 p. m.', null, false);
INSERT INTO bet.pronostico_partido( id, id_pronostico, id_partido, estado, fecha_creacion, fecha_modificacion, empate ) VALUES ( 9, 10, 2, 'ACTIVO', '2022-09-01 11:54:53 p. m.', null, false);
INSERT INTO bet.equipo( id, nombre, pais, tipo, id_grupo, fecha_creacion, fecha_modificacion, imagen ) VALUES ( 1, 'QATAR', 'Qatar', 'SELECCION', 1, '2022-05-29 11:21:40 p. m.', null, null);
INSERT INTO bet.equipo( id, nombre, pais, tipo, id_grupo, fecha_creacion, fecha_modificacion, imagen ) VALUES ( 3, 'ECUADOR', 'Ecuador', 'SELECCION', 1, '2022-05-29 11:21:40 p. m.', null, null);
INSERT INTO bet.equipo( id, nombre, pais, tipo, id_grupo, fecha_creacion, fecha_modificacion, imagen ) VALUES ( 4, 'SENEGAL', 'Senegal', 'SELECCION', 1, '2022-05-29 11:21:40 p. m.', null, null);
INSERT INTO bet.equipo( id, nombre, pais, tipo, id_grupo, fecha_creacion, fecha_modificacion, imagen ) VALUES ( 5, 'PAISES BAJOS', 'Paises Bajos', 'SELECCION', 1, '2022-05-29 11:21:40 p. m.', null, null);
INSERT INTO bet.equipo( id, nombre, pais, tipo, id_grupo, fecha_creacion, fecha_modificacion, imagen ) VALUES ( 6, 'INGLATERRA', 'Iglaterra', 'SELECCION', 2, '2022-05-29 11:30:55 p. m.', null, null);
INSERT INTO bet.equipo( id, nombre, pais, tipo, id_grupo, fecha_creacion, fecha_modificacion, imagen ) VALUES ( 7, 'IRAN', 'Iran', 'SELECCION', 2, '2022-05-29 11:30:55 p. m.', null, null);
INSERT INTO bet.equipo( id, nombre, pais, tipo, id_grupo, fecha_creacion, fecha_modificacion, imagen ) VALUES ( 8, 'EEUU', 'Estados Unidos', 'SELECCION', 2, '2022-05-29 11:30:55 p. m.', null, null);
INSERT INTO bet.equipo( id, nombre, pais, tipo, id_grupo, fecha_creacion, fecha_modificacion, imagen ) VALUES ( 9, 'UCRANIA', 'Ucrania', 'SELECCION', 2, '2022-05-29 11:30:55 p. m.', null, null);
INSERT INTO bet.partido_equipo( id, id_equipo, id_partido, cantidad_gol, estado, fecha_creacion, fecha_modificacion ) VALUES ( 1, 1, 1, 0, 'PENDIENTE', '2022-06-01 01:46:04 a. m.', null);
INSERT INTO bet.partido_equipo( id, id_equipo, id_partido, cantidad_gol, estado, fecha_creacion, fecha_modificacion ) VALUES ( 2, 3, 1, 0, 'PENDIENTE', '2022-06-01 01:46:04 a. m.', null);
INSERT INTO bet.partido_equipo( id, id_equipo, id_partido, cantidad_gol, estado, fecha_creacion, fecha_modificacion ) VALUES ( 3, 4, 2, 0, 'PENDIENTE', '2022-06-01 01:51:21 a. m.', null);
INSERT INTO bet.partido_equipo( id, id_equipo, id_partido, cantidad_gol, estado, fecha_creacion, fecha_modificacion ) VALUES ( 4, 5, 2, 0, 'PENDIENTE', '2022-06-01 01:51:21 a. m.', null);
INSERT INTO bet.pronostico_equipo( id, id_pronostico_partido, id_partido_equipo, estado, fecha_creacion, fecha_modificacion, cantidad_gol ) VALUES ( 7, 4, 1, 'ACTIVO', '2022-06-20 12:36:43 p. m.', null, 0);
INSERT INTO bet.pronostico_equipo( id, id_pronostico_partido, id_partido_equipo, estado, fecha_creacion, fecha_modificacion, cantidad_gol ) VALUES ( 8, 4, 2, 'ACTIVO', '2022-06-20 12:36:43 p. m.', null, 1);
INSERT INTO bet.pronostico_equipo( id, id_pronostico_partido, id_partido_equipo, estado, fecha_creacion, fecha_modificacion, cantidad_gol ) VALUES ( 9, 5, 3, 'ACTIVO', '2022-06-20 12:36:43 p. m.', null, 1);
INSERT INTO bet.pronostico_equipo( id, id_pronostico_partido, id_partido_equipo, estado, fecha_creacion, fecha_modificacion, cantidad_gol ) VALUES ( 10, 5, 4, 'ACTIVO', '2022-06-20 12:36:43 p. m.', null, 1);
INSERT INTO bet.pronostico_equipo( id, id_pronostico_partido, id_partido_equipo, estado, fecha_creacion, fecha_modificacion, cantidad_gol ) VALUES ( 11, 6, 1, 'ACTIVO', '2022-09-01 11:54:31 p. m.', null, 3);
INSERT INTO bet.pronostico_equipo( id, id_pronostico_partido, id_partido_equipo, estado, fecha_creacion, fecha_modificacion, cantidad_gol ) VALUES ( 12, 6, 2, 'ACTIVO', '2022-09-01 11:54:31 p. m.', null, 0);
INSERT INTO bet.pronostico_equipo( id, id_pronostico_partido, id_partido_equipo, estado, fecha_creacion, fecha_modificacion, cantidad_gol ) VALUES ( 13, 7, 3, 'ACTIVO', '2022-09-01 11:54:31 p. m.', null, 1);
INSERT INTO bet.pronostico_equipo( id, id_pronostico_partido, id_partido_equipo, estado, fecha_creacion, fecha_modificacion, cantidad_gol ) VALUES ( 14, 7, 4, 'ACTIVO', '2022-09-01 11:54:31 p. m.', null, 2);
INSERT INTO bet.pronostico_equipo( id, id_pronostico_partido, id_partido_equipo, estado, fecha_creacion, fecha_modificacion, cantidad_gol ) VALUES ( 15, 8, 1, 'ACTIVO', '2022-09-01 11:54:53 p. m.', null, 3);
INSERT INTO bet.pronostico_equipo( id, id_pronostico_partido, id_partido_equipo, estado, fecha_creacion, fecha_modificacion, cantidad_gol ) VALUES ( 16, 8, 2, 'ACTIVO', '2022-09-01 11:54:53 p. m.', null, 0);
INSERT INTO bet.pronostico_equipo( id, id_pronostico_partido, id_partido_equipo, estado, fecha_creacion, fecha_modificacion, cantidad_gol ) VALUES ( 17, 9, 3, 'ACTIVO', '2022-09-01 11:54:53 p. m.', null, 1);
INSERT INTO bet.pronostico_equipo( id, id_pronostico_partido, id_partido_equipo, estado, fecha_creacion, fecha_modificacion, cantidad_gol ) VALUES ( 18, 9, 4, 'ACTIVO', '2022-09-01 11:54:53 p. m.', null, 2);