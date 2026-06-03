-- =============================================
-- CREATE SALES TABLE
-- =============================================
CREATE TABLE sales (
    id        SERIAL PRIMARY KEY,
    rep       VARCHAR(50)    NOT NULL,
    region    VARCHAR(50)    NOT NULL,
    product   VARCHAR(100)   NOT NULL,
    amount    NUMERIC(10, 2) NOT NULL,
    quantity  INT            NOT NULL,
    sale_date DATE           NOT NULL
);

-- =============================================
-- INSERT 10 MOCK RECORDS
-- =============================================
INSERT INTO sales (rep, region, product, amount, quantity, sale_date) VALUES
('Alice',   'North', 'Laptop',     1200.00,  2, '2024-01-05'),
('Bob',     'South', 'Monitor',     450.00,  3, '2024-01-08'),
('Alice',   'North', 'Keyboard',     85.00,  5, '2024-01-12'),
('Carol',   'East',  'Laptop',     1350.00,  1, '2024-01-15'),
('Bob',     'South', 'Mouse',        40.00, 10, '2024-01-18'),
('David',   'West',  'Headphones',  220.00,  4, '2024-02-02'),
('Alice',   'North', 'Monitor',     470.00,  2, '2024-02-05'),
('Carol',   'East',  'Keyboard',     90.00,  6, '2024-02-09'),
('David',   'West',  'Laptop',     1100.00,  3, '2024-02-14'),
('Bob',     'South', 'Headphones',  200.00,  5, '2024-02-20');

-- 1. Total revenue per sales rep
SELECT rep, SUM(amount) AS total_revenue
FROM sales
GROUP BY rep
ORDER BY total_revenue DESC;

-- 2. Number of sales per region
SELECT region, COUNT(*) AS num_sales
FROM sales
GROUP BY region;

-- 3. Best-selling product by quantity sold
SELECT product, SUM(quantity) AS units_sold
FROM sales
GROUP BY product
ORDER BY units_sold DESC;

-- 4. Monthly revenue trend
SELECT DATE_TRUNC('month', sale_date) AS month,
       SUM(amount) AS monthly_revenue
FROM sales
GROUP BY month
ORDER BY month;

-- 5. Reps who generated more than $2000 in total
SELECT rep, SUM(amount) AS total
FROM sales
GROUP BY rep
HAVING SUM(amount) > 2000;

-- 6. Average deal size by region
SELECT region, ROUND(AVG(amount), 2) AS avg_deal_size
FROM sales
GROUP BY region;

-- 7. Revenue breakdown by rep AND product
SELECT rep, product, SUM(amount) AS total
FROM sales
GROUP BY rep, product
ORDER BY rep, total DESC;