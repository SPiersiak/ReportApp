-- PROCEDURE: public.insert_dummy_data(bigint, bigint)

-- DROP PROCEDURE IF EXISTS public.insert_dummy_data(bigint, bigint);

CREATE OR REPLACE PROCEDURE public.insert_dummy_data(
	IN user_id bigint,
	IN premise_id bigint)
LANGUAGE 'plpgsql'
AS $BODY$
DECLARE
   total INT = 0;
   p_name varchar;
   r_name varchar;   
begin
    WHILE  total <= 300 loop
		select premise_name into p_name from premises where id = premise_id;
		total := total + 1;
		r_name := CONCAT('Report', cast(total as varchar), ' from ', p_name);
		INSERT INTO public.reports(report_name, report_date_time, user_id, premise_id)
		values(r_name, (current_timestamp - make_interval(days => 360)) + make_interval(days => total), user_id, premise_id);
	END loop;
end;
$BODY$;
ALTER PROCEDURE public.insert_dummy_data(bigint, bigint)
    OWNER TO postgres;
