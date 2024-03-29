-- Table: public.premises

-- DROP TABLE IF EXISTS public.premises;

CREATE TABLE IF NOT EXISTS public.premises
(
    id integer NOT NULL DEFAULT nextval('premises_id_seq'::regclass),
    premise_name character varying(100) COLLATE pg_catalog."default",
    CONSTRAINT premises_pkey PRIMARY KEY (id)
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public.premises
    OWNER to postgres;