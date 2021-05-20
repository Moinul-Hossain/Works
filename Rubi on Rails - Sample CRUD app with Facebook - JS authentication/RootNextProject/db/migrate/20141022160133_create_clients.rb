class CreateClients < ActiveRecord::Migration
  def change
    create_table :clients do |t|
      t.string :name
      t.string :contact_name
      t.string :contact_phone
      t.string :contact_email
      t.string :facebook_email
      t.string :facebook_account

      t.timestamps
    end
  end
end
