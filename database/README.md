# SQL Test Assignment

Attached is a mysqldump of a database to be used during the test.

Below are the questions for this test. Please enter a full, complete, working SQL statement under each question. We do not want the answer to the question. We want the SQL command to derive the answer. We will copy/paste these commands to test the validity of the answer.

**Example:**

_Q. Select all users_

- Please return at least first_name and last_name

SELECT first_name, last_name FROM users;


------

**— Test Starts Here —**

1. Select users whose id is either 3,2 or 4
- Please return at least: all user fields
--SELECT *
FROM users
WHERE users.id IN(3,2,4);

2. Count how many basic and premium listings each active user has
- Please return at least: first_name, last_name, basic, premium
SELECT USU.first_name AS NAME, USU.last_name AS LAST_NAME,
(SELECT COUNT(listings.status) FROM listings INNER JOIN users ON listings.user_id = users.id WHERE listings.status = 2 AND users.id = USU.id) BASIC,
(SELECT COUNT(listings.status) FROM listings INNER JOIN users ON listings.user_id = users.id WHERE listings.status = 3 AND users.id = USU.id) PREMIUM
FROM users USU WHERE USU.status = 2;

3. Show the same count as before but only if they have at least ONE premium listing
- Please return at least: first_name, last_name, basic, premium
SELECT USU.first_name AS NAME, USU.last_name AS LAST_NAME,
(SELECT COUNT(listings.status) FROM listings INNER JOIN users ON listings.user_id = users.id WHERE listings.status = 2 AND users.id = USU.id) BASIC,
(SELECT COUNT(listings.status) FROM listings INNER JOIN users ON listings.user_id = users.id WHERE listings.status = 3 AND users.id = USU.id) PREMIUM
FROM users USU WHERE USU.status = 2
AND (SELECT COUNT(listings.status) FROM listings INNER JOIN users ON listings.user_id = users.id WHERE listings.status = 3 AND users.id = USU.id) > 0;

4. How much revenue has each active vendor made in 2013
- Please return at least: first_name, last_name, currency, revenue
SELECT users.first_name, users.last_name, clicks.currency, SUM(clicks.price)
FROM users
INNER JOIN listings on users.id = listings.user_id
INNER JOIN clicks on clicks.listing_id = listings.id
WHERE users.status = 2
GROUP BY users.first_name, users.last_name, clicks.currency;

5. Insert a new click for listing id 3, at $4.00
- Find out the id of this new click. Please return at least: id
INSERT INTO clicks (listing_id, price, currency)
VALUES (3,4.00,'USD');

SELECT *
FROM clicks
WHERE created IS NULL AND listing_id = 3 AND price = 4.00 AND currency = 'USD';

6. Show listings that have not received a click in 2013
- Please return at least: listing_name
SELECT *
FROM listings
WHERE id NOT IN (SELECT DISTINCT listing_id FROM clicks WHERE YEAR(created) = 2013);
Other way
SELECT *
FROM listings
WHERE id NOT IN (SELECT DISTINCT listing_id FROM clicks WHERE created BETWEEN '2013-01-01' AND '2013-12-31' );

7. For each year show number of listings clicked and number of vendors who owned these listings
- Please return at least: date, total_listings_clicked, total_vendors_affected
SELECT clicks.created as DATE, SUM(clicks.listing_id) as TOTAL_LISTINGS_AFFECTED, SUM(users.id) as TOTAL_VENDORS_AFFECTED
FROM clicks
INNER JOIN listings ON clicks.listing_id = listings.id
INNER JOIN users ON listings.user_id = users.id
GROUP BY clicks.created;

8. Return a comma separated string of listing names for all active vendors
- Please return at least: first_name, last_name, listing_names
SELECT CONCAT_WS(', ', users.first_name, users.last_name, listings.name) as LISTING_NAME_FROM_ACTIVE_VENDORS
FROM listings
INNER JOIN users ON listings.user_id = users.id
WHERE users.status = 2;