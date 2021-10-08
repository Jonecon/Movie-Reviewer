SELECT * FROM movie;

SELECT * FROM Movie WHERE summary like '%nulla%';
CREATE INDEX idx_MovDesc ON Movie(Summary); 
DROP INDEX idx_MovDesc;

CREATE TABLE plan_table
    (   statement_id VARCHAR2(30),
        timestamp DATE,
        remarks VARCHAR2(80),
        operation VARCHAR2(30),
        options VARCHAR2(30),
        object_node VARCHAR2(128),
        object_owner VARCHAR2(30),
        object_name VARCHAR2(30),
        object_instance NUMERIC,
        object_type VARCHAR2(30),
        optimizer VARCHAR2(255),
        search_columns NUMERIC,
        id NUMERIC,
        parent_id NUMERIC,
        position NUMERIC,
        cost NUMERIC,
        cardinality NUMERIC,
        bytes NUMERIC,
        other_tag VARCHAR2(255),
        other LONG  );
        
EXPLAIN PLAN
    SET STATEMENT_ID = 'TreeIndex'
    FOR SELECT *
        FROM movie
        WHERE summary like '%nulla%';
        
EXPLAIN PLAN
    SET STATEMENT_ID = 'Base'
    FOR SELECT *
        FROM movie
        WHERE summary like '%nulla%';
        
SELECT LPAD(' ',2*(LEVEL-1)) || operation ||' '|| options ||' '|| object_name ||' '||
DECODE(id, 0, 'Cost = '||position) "Query Plan"
FROM plan_table
START WITH id = 0 AND statement_id = 'TreeIndex'
CONNECT BY PRIOR id = parent_id
AND statement_id ='TreeIndex';

SELECT LPAD(' ',2*(LEVEL-1)) || operation ||' '|| options ||' '|| object_name ||' '||
DECODE(id, 0, 'Cost = '||position) "Query Plan"
FROM plan_table
START WITH id = 0 AND statement_id = 'Base'
CONNECT BY PRIOR id = parent_id
AND statement_id ='Base';

SELECT * FROM Movie WHERE movieduration BETWEEN 60 AND 120;
CREATE INDEX idx_MovDuration ON Movie(Summary); 
DROP INDEX idx_MovDesc;