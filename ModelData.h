//  To parse this JSON data, first install
//
//      Boost     http://www.boost.org
//      json.hpp  https://github.com/nlohmann/json
//
//  Then include this file, and then do
//
//     ModelDataClass data = nlohmann::json::parse(jsonString);

#pragma once

#include <iostream>
#include <string>
#include <fstream>
#include <nlohmann/json.hpp>
#include <stdexcept>
#include <regex>


namespace ModelData {
    using nlohmann::json;

    inline json get_untyped(const json& j, const char* property) {
        if (j.find(property) != j.end()) {
            return j.at(property).get<json>();
        }
        return json();
    }

    inline json get_untyped(const json& j, std::string property) {
        return get_untyped(j, property.data());
    }

    class Region {
    public:
        Region() = default;
        virtual ~Region() = default;

    private:
        int64_t point_x;
        int64_t point_y;
        int64_t image_width;
        int64_t image_height;
        std::string template_image_path;

    public:
        const int64_t& get_point_x() const { return point_x; }
        int64_t& get_mutable_point_x() { return point_x; }
        void set_point_x(const int64_t& value) { this->point_x = value; }

        const int64_t& get_point_y() const { return point_y; }
        int64_t& get_mutable_point_y() { return point_y; }
        void set_point_y(const int64_t& value) { this->point_y = value; }

        const int64_t& get_image_width() const { return image_width; }
        int64_t& get_mutable_image_width() { return image_width; }
        void set_image_width(const int64_t& value) { this->image_width = value; }

        const int64_t& get_image_height() const { return image_height; }
        int64_t& get_mutable_image_height() { return image_height; }
        void set_image_height(const int64_t& value) { this->image_height = value; }

        const std::string& get_template_image_path() const { return template_image_path; }
        std::string& get_mutable_template_image_path() { return template_image_path; }
        void set_template_image_path(const std::string& value) { this->template_image_path = value; }
    };

    class List {
    public:
        List() = default;
        virtual ~List() = default;

    private:
        std::string node_name;
        std::vector<int64_t> node_range;
        int64_t node_val;

    public:
        const std::string& get_node_name() const { return node_name; }
        std::string& get_mutable_node_name() { return node_name; }
        void set_node_name(const std::string& value) { this->node_name = value; }

        const std::vector<int64_t>& get_node_range() const { return node_range; }
        std::vector<int64_t>& get_mutable_node_range() { return node_range; }
        void set_node_range(const std::vector<int64_t>& value) { this->node_range = value; }

        const int64_t& get_node_val() const { return node_val; }
        int64_t& get_mutable_node_val() { return node_val; }
        void set_node_val(const int64_t& value) { this->node_val = value; }
    };

    class CheckCheckEdge {
    public:
        CheckCheckEdge() = default;
        virtual ~CheckCheckEdge() = default;

    private:
        std::vector<Region> edge_regions;
        std::vector<List> list;
        int64_t angle_tolerance;
        int64_t threshold;
        int64_t distance;
        int64_t distance_tolerance;
        int64_t out_pos;
        int64_t in_pos;
        int64_t direction;

    public:
        const std::vector<Region>& get_edge_regions() const { return edge_regions; }
        std::vector<Region>& get_mutable_edge_regions() { return edge_regions; }
        void set_edge_regions(const std::vector<Region>& value) { this->edge_regions = value; }

        const std::vector<List>& get_list() const { return list; }
        std::vector<List>& get_mutable_list() { return list; }
        void set_list(const std::vector<List>& value) { this->list = value; }

        const int64_t& get_angle_tolerance() const { return angle_tolerance; }
        int64_t& get_mutable_angle_tolerance() { return angle_tolerance; }
        void set_angle_tolerance(const int64_t& value) { this->angle_tolerance = value; }

        const int64_t& get_threshold() const { return threshold; }
        int64_t& get_mutable_threshold() { return threshold; }
        void set_threshold(const int64_t& value) { this->threshold = value; }

        const int64_t& get_distance() const { return distance; }
        int64_t& get_mutable_distance() { return distance; }
        void set_distance(const int64_t& value) { this->distance = value; }

        const int64_t& get_distance_tolerance() const { return distance_tolerance; }
        int64_t& get_mutable_distance_tolerance() { return distance_tolerance; }
        void set_distance_tolerance(const int64_t& value) { this->distance_tolerance = value; }

        const int64_t& get_out_pos() const { return out_pos; }
        int64_t& get_mutable_out_pos() { return out_pos; }
        void set_out_pos(const int64_t& value) { this->out_pos = value; }

        const int64_t& get_in_pos() const { return in_pos; }
        int64_t& get_mutable_in_pos() { return in_pos; }
        void set_in_pos(const int64_t& value) { this->in_pos = value; }

        const int64_t& get_direction() const { return direction; }
        int64_t& get_mutable_direction() { return direction; }
        void set_direction(const int64_t& value) { this->direction = value; }
    };

    class CheckTemplate {
    public:
        CheckTemplate() = default;
        virtual ~CheckTemplate() = default;

    private:
        std::vector<List> list;
        std::vector<Region> temp_regions;
        int64_t match_score;
        int64_t temp_threshold;
        int64_t binary_threshold;
        nlohmann::json template_image_path;

    public:
        const std::vector<List>& get_list() const { return list; }
        std::vector<List>& get_mutable_list() { return list; }
        void set_list(const std::vector<List>& value) { this->list = value; }

        const std::vector<Region>& get_temp_regions() const { return temp_regions; }
        std::vector<Region>& get_mutable_temp_regions() { return temp_regions; }
        void set_temp_regions(const std::vector<Region>& value) { this->temp_regions = value; }

        const int64_t& get_match_score() const { return match_score; }
        int64_t& get_mutable_match_score() { return match_score; }
        void set_match_score(const int64_t& value) { this->match_score = value; }

        const int64_t& get_temp_threshold() const { return temp_threshold; }
        int64_t& get_mutable_temp_threshold() { return temp_threshold; }
        void set_temp_threshold(const int64_t& value) { this->temp_threshold = value; }

        const int64_t& get_binary_threshold() const { return binary_threshold; }
        int64_t& get_mutable_binary_threshold() { return binary_threshold; }
        void set_binary_threshold(const int64_t& value) { this->binary_threshold = value; }

        const nlohmann::json& get_template_image_path() const { return template_image_path; }
        nlohmann::json& get_mutable_template_image_path() { return template_image_path; }
        void set_template_image_path(const nlohmann::json& value) { this->template_image_path = value; }
    };

    class ModelDataClass {
    public:
        ModelDataClass() = default;
        virtual ~ModelDataClass() = default;

    private:
        std::string model_name;
        int64_t camera_exposer;
        std::string template_image_path;
        std::string original_image_path;
        std::vector<CheckTemplate> check_template;
        std::vector<CheckCheckEdge> check_check_edges;
        std::string template_coordinate;

    public:
        const std::string& get_model_name() const { return model_name; }
        std::string& get_mutable_model_name() { return model_name; }
        void set_model_name(const std::string& value) { this->model_name = value; }

        const int64_t& get_camera_exposer() const { return camera_exposer; }
        int64_t& get_mutable_camera_exposer() { return camera_exposer; }
        void set_camera_exposer(const int64_t& value) { this->camera_exposer = value; }

        const std::string& get_template_image_path() const { return template_image_path; }
        std::string& get_mutable_template_image_path() { return template_image_path; }
        void set_template_image_path(const std::string& value) { this->template_image_path = value; }

        const std::string& get_original_image_path() const { return original_image_path; }
        std::string& get_mutable_original_image_path() { return original_image_path; }
        void set_original_image_path(const std::string& value) { this->original_image_path = value; }

        const std::vector<CheckTemplate>& get_check_template() const { return check_template; }
        std::vector<CheckTemplate>& get_mutable_check_template() { return check_template; }
        void set_check_template(const std::vector<CheckTemplate>& value) { this->check_template = value; }

        const std::vector<CheckCheckEdge>& get_check_check_edges() const { return check_check_edges; }
        std::vector<CheckCheckEdge>& get_mutable_check_check_edges() { return check_check_edges; }
        void set_check_check_edges(const std::vector<CheckCheckEdge>& value) { this->check_check_edges = value; }

        const std::string& get_template_coordinate() const { return template_coordinate; }
        std::string& get_mutable_template_coordinate() { return template_coordinate; }
        void set_template_coordinate(const std::string& value) { this->template_coordinate = value; }
    };

    void from_json(const json& j, ModelData::Region& x);
    void to_json(json& j, const ModelData::Region& x);

    void from_json(const json& j, ModelData::List& x);
    void to_json(json& j, const ModelData::List& x);

    void from_json(const json& j, ModelData::CheckCheckEdge& x);
    void to_json(json& j, const ModelData::CheckCheckEdge& x);

    void from_json(const json& j, ModelData::CheckTemplate& x);
    void to_json(json& j, const ModelData::CheckTemplate& x);

    void from_json(const json& j, ModelData::ModelDataClass& x);
    void to_json(json& j, const ModelData::ModelDataClass& x);

    inline void from_json(const json& j, ModelData::Region& x) {
        x.set_point_x(j.at("point_x").get<int64_t>());
        x.set_point_y(j.at("point_y").get<int64_t>());
        x.set_image_width(j.at("imageWidth").get<int64_t>());
        x.set_image_height(j.at("imageHeight").get<int64_t>());
        x.set_template_image_path(j.at("template_image_path").get<std::string>());
    }

    inline void to_json(json& j, const ModelData::Region& x) {
        j = json::object();
        j["point_x"] = x.get_point_x();
        j["point_y"] = x.get_point_y();
        j["imageWidth"] = x.get_image_width();
        j["imageHeight"] = x.get_image_height();
        j["template_image_path"] = x.get_template_image_path();
    }

    inline void from_json(const json& j, ModelData::List& x) {
        x.set_node_name(j.at("nodeName").get<std::string>());
        x.set_node_range(j.at("nodeRange").get<std::vector<int64_t>>());
        x.set_node_val(j.at("nodeVal").get<int64_t>());
    }

    inline void to_json(json& j, const ModelData::List& x) {
        j = json::object();
        j["nodeName"] = x.get_node_name();
        j["nodeRange"] = x.get_node_range();
        j["nodeVal"] = x.get_node_val();
    }

    inline void from_json(const json& j, ModelData::CheckCheckEdge& x) {
        x.set_edge_regions(j.at("edgeRegions").get<std::vector<ModelData::Region>>());
        x.set_list(j.at("List").get<std::vector<ModelData::List>>());
        x.set_angle_tolerance(j.at("angleTolerance").get<int64_t>());
        x.set_threshold(j.at("threshold").get<int64_t>());
        x.set_distance(j.at("distance").get<int64_t>());
        x.set_distance_tolerance(j.at("distanceTolerance").get<int64_t>());
        x.set_out_pos(j.at("outPos").get<int64_t>());
        x.set_in_pos(j.at("inPos").get<int64_t>());
        x.set_direction(j.at("direction").get<int64_t>());
    }

    inline void to_json(json& j, const ModelData::CheckCheckEdge& x) {
        j = json::object();
        j["edgeRegions"] = x.get_edge_regions();
        j["List"] = x.get_list();
        j["angleTolerance"] = x.get_angle_tolerance();
        j["threshold"] = x.get_threshold();
        j["distance"] = x.get_distance();
        j["distanceTolerance"] = x.get_distance_tolerance();
        j["outPos"] = x.get_out_pos();
        j["inPos"] = x.get_in_pos();
        j["direction"] = x.get_direction();
    }

    inline void from_json(const json& j, ModelData::CheckTemplate& x) {
        x.set_list(j.at("List").get<std::vector<ModelData::List>>());
        x.set_temp_regions(j.at("tempRegions").get<std::vector<ModelData::Region>>());
        x.set_match_score(j.at("MatchScore").get<int64_t>());
        x.set_temp_threshold(j.at("TempThreshold").get<int64_t>());
        x.set_binary_threshold(j.at("BinaryThreshold").get<int64_t>());
        x.set_template_image_path(ModelData::get_untyped(j, "template_image_path"));
    }

    inline void to_json(json& j, const ModelData::CheckTemplate& x) {
        j = json::object();
        j["List"] = x.get_list();
        j["tempRegions"] = x.get_temp_regions();
        j["MatchScore"] = x.get_match_score();
        j["TempThreshold"] = x.get_temp_threshold();
        j["BinaryThreshold"] = x.get_binary_threshold();
        j["template_image_path"] = x.get_template_image_path();
    }

    inline void from_json(const json& j, ModelData::ModelDataClass& x) {
        x.set_model_name(j.at("model_name").get<std::string>());
        x.set_camera_exposer(j.at("camera_exposer").get<int64_t>());
        x.set_template_image_path(j.at("TemplateImagePath").get<std::string>());
        x.set_original_image_path(j.at("OriginalImagePath").get<std::string>());
        x.set_check_template(j.at("CheckTemplate").get<std::vector<ModelData::CheckTemplate>>());
        x.set_check_check_edges(j.at("CheckCheckEdges").get<std::vector<ModelData::CheckCheckEdge>>());
        x.set_template_coordinate(j.at("TemplateCoordinate").get<std::string>());
    }

    inline void to_json(json& j, const ModelData::ModelDataClass& x) {
        j = json::object();
        j["model_name"] = x.get_model_name();
        j["camera_exposer"] = x.get_camera_exposer();
        j["TemplateImagePath"] = x.get_template_image_path();
        j["OriginalImagePath"] = x.get_original_image_path();
        j["CheckTemplate"] = x.get_check_template();
        j["CheckCheckEdges"] = x.get_check_check_edges();
        j["TemplateCoordinate"] = x.get_template_coordinate();
    }

}


