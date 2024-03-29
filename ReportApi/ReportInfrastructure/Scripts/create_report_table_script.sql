-- Table: public.reports

-- DROP TABLE IF EXISTS public.reports;

CREATE TABLE IF NOT EXISTS public.reports
(
    id integer NOT NULL DEFAULT nextval('reports_id_seq'::regclass),
    report_name character varying(150) COLLATE pg_catalog."default",
    report_date_time timestamp with time zone NOT NULL,
    user_id integer NOT NULL DEFAULT nextval('reports_user_id_seq'::regclass),
    premise_id integer NOT NULL DEFAULT nextval('reports_premise_id_seq'::regclass),
    CONSTRAINT reports_pkey PRIMARY KEY (id),
    CONSTRAINT report_premise_id FOREIGN KEY (premise_id)
        REFERENCES public.premises (id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION,
    CONSTRAINT report_user_id FOREIGN KEY (user_id)
        REFERENCES public.users (id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public.reports
    OWNER to postgres;